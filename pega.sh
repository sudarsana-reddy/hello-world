#!/bin/bash
echo "Starting the srcipt"

# PEGA DETAILS
PEGA_DM_REST_URL=$1
PEGA_DM_CLIENT_ID=$2
PEGA_DM_CLIENT_SECRET=$3
PEGA_PIEPLINE_ID=$4
PEGA_PROD_NAME=$5
PEGA_PROD_VERSION=$6

#GLOBAL VARIABLES - CONSTANTS
THRESHOLD_WAIT_TIME=120
WAIT_INTERVAL_TIME=60

# global variables
wait_time_elapsed=0
is_development_complete=false
is_development_error=false
deployment_satus_response=""
deployment_satus=""
deploymentId=""
pipelineData=""

# Get Access Token
function getAccessToken() {
  token_response=$(
    curl --location --request POST "$PEGA_DM_REST_URL/oauth2/v1/token" \
    --header "Content-Type: application/x-www-form-urlencoded" \
    --header "Accept: application/json" \
    --data-urlencode "client_id=$PEGA_DM_CLIENT_ID" \
    --data-urlencode "client_secret=$PEGA_DM_CLIENT_SECRET" \
    --data-urlencode "grant_type=client_credentials"
  )

  access_token=$(echo $token_response | jq -j ".access_token")
  echo "$access_token"
}

# Get Pipeline Data
function getPipelineData() {
  getAccessToken
  echo "Getting the Pipeline Data for $PEGA_PIEPLINE_ID"
  pipelineData=$(curl --location --request GET "$PEGA_DM_REST_URL/DeploymentManager/v1/pipelines/$PEGA_PIEPLINE_ID" --header "Authorization: Bearer $access_token")
  echo "PipelineData: $pipelineData"

  invalid_token=$(echo $abort_response | jq -r '.errors[].ID')
  if [[ "$invalid_token" == "invalid_token" ]]; then
    echo "Token Expired. Getting new access token"
    getAccessToken
    pipelineData=$(curl --location --request GET "$PEGA_DM_REST_URL/DeploymentManager/v1/pipelines/$PEGA_PIEPLINE_ID" --header "Authorization: Bearer $access_token")
    echo "PipelineData:"
    echo $PipelineData | jq
  fi
}

# Update Pipeline Data
function updatePipelineData() {
  getPipelineData

  updateRequired=false
  echo "Updating the Pipeline Data for $PEGA_PIEPLINE_ID"
  existingProductVersion=$(echo $pipelineData | jq '.pipelineParameters[] | select(.name == "productVersion") | .value')
  existingProductName=$(echo $pipelineData | jq '.pipelineParameters[] | select(.name == "productName") | .value')

  if [ $existingProductVersion != "$PEGA_PROD_VERSION" ]; then
    updateRequired=true
    echo "Existing $existingProductVersion and Required $PEGA_PROD_VERSION Versions are Not Equal. Updating the product version"
    productVersion=$(echo $pipelineData | jq '.pipelineParameters[] | select(.name == "productVersion") | .value |="'"$PEGA_PROD_VERSION"'"')
    echo "Updated Product Version"
    echo $productVersion | jq
    pipelineData=$(echo $pipelineData | jq 'del(.pipelineParameters[] | select(.name == "productVersion"))')
    pipelineData=$(echo $pipelineData | jq ".pipelineParameters += [$productVersion]")
  else
    echo "There is no Change In Product Version. Not Updating the Version."
  fi

  if [ $existingProductName != "$PEGA_PROD_NAME" ]; then
    updateRequired=true
    echo "Existing $existingProductName and Required $PEGA_PROD_NAME Versions are Not Equal. Updating the product version"
    productName=$(echo $pipelineData | jq '.pipelineParameters[] | select(.name == "productName") | .value |="'"$PEGA_PROD_NAME"'"')
    echo "Updated Product Name"
    echo $productName | jq
    pipelineData=$(echo $pipelineData | jq 'del(.pipelineParameters[] | select(.name == "productName"))')
    pipelineData=$(echo $pipelineData | jq ".pipelineParameters += [$productName]")
  else
    echo "There is no Change In Product Name. Not Updating the Name."
  fi

  if [[ "$updateRequired" == "true" ]]; then
    echo "Update Require. Update request with: $pipelineData"
    echo $pipelineData | jq >>temp.json
    updatedPipelineData=$(curl --location --request PUT "$PEGA_DM_REST_URL/DeploymentManager/v1/pipelines/$PEGA_PIEPLINE_ID" --header "Authorization: Bearer $access_token" --data-raw "$(cat ./temp.json | grep -v '^\s*//')")
    echo "PipelineData After Update: $updatedPipelineData"

    invalid_token=$(echo $abort_response | jq -r '.errors[].ID')
    if [[ "$invalid_token" == "invalid_token" ]]; then
      echo "Token Expired. Getting new access token"
      getAccessToken
      updatedPipelineData=$(curl --location --request PUT "$PEGA_DM_REST_URL/DeploymentManager/v1/pipelines/$PEGA_PIEPLINE_ID" --header "Authorization: Bearer $access_token" --data-raw --data-raw "$(cat ./temp.json | grep -v '^\s*//')")
      echo "PipelineData After Update: $updatedPipelineData"
    fi

  else
    echo "Update Not Required. Skipping the step"
  fi
}

# Trigger a deployment through PDM Rest API
function triggerDeployment() {

  echo "Getting access token"
  getAccessToken

  echo "Triggering Deployment API"
  deployment=$(curl --location --request POST "$PEGA_DM_REST_URL/DeploymentManager/v1/pipelines/$PEGA_PIEPLINE_ID/deployments" --header "Authorization: Bearer $access_token")
  echo "deployment: $deployment"
  deploymentId=$(echo $deployment | jq -r ".deploymentID")
  echo "$deploymentId"
}

# Abort the deployment on error
function abortDeployment() {
  errors=$(echo $deployment_satus_response | jq -r '.taskList[] | select(.status | contains("Resolved-Completed")| not)' | jq -r '.errors[].errorMessage')
  echo "The Errors are: $errors"
  echo "#############Aborting the Deployment as there is error#############"
  abort_response=$(
    curl --location --request PUT "$PEGA_DM_REST_URL/DeploymentManager/v1/deployments/$deploymentId/abort" \
    --header "Authorization: Bearer $access_token" \
    --data-raw '{ "reasonForAbort": "Build got errored out." }'
  )

  #Check for token expiry
  invalid_token=$(echo $abort_response | jq -r '.errors[].ID')
  if [[ "$invalid_token" == "invalid_token" ]]; then
    echo "Token Expired. Getting new access token"
    getAccessToken
    abort_response=$(
      curl --location --request PUT "$PEGA_DM_REST_URL/DeploymentManager/v1/deployments/$deploymentId/abort" \
      --header "Authorization: Bearer $access_token" \
      --data-raw '{ "reasonForAbort": "Build got errored out." }'
    )
  fi

  echo "Abort Response: $abort_response"
  status=$(echo $abort_response | jq -r ".status")
  echo "Abort Status: $status"
  exit 1
}

# Wait for the deployment to complete or error out
function waitForDeploymentToComplete() {
  while [[ "$is_development_complete" -eq "false" && "$is_development_error" -eq "false" && $THRESHOLD_WAIT_TIME -gt $wait_time_elapsed ]]; do
    echo "Waiting for $WAIT_INTERVAL_TIME seconds"
    sleep $WAIT_INTERVAL_TIME

    echo "---------------------Getting Deployment Status---------------------"
    deployment_satus_response=$(curl --location --request GET "$PEGA_DM_REST_URL/DeploymentManager/v1/deployments/$deploymentId" --header "Authorization: Bearer $access_token")

    #Check for token expiry
    invalid_token=$(echo $deployment_satus_response | jq -r '.errors[].ID')
    if [[ $invalid_token == "invalid_token" ]]; then
      echo "Token Expired. Getting new access token"
      getAccessToken
      echo "---------------------Getting Deployment Status---------------------"
      deployment_satus_response=$(curl --location --request GET "$PEGA_DM_REST_URL/DeploymentManager/v1/deployments/$deploymentId" --header "Authorization: Bearer $access_token")
    fi

    deployment_satus=$(echo $deployment_satus_response | jq -r ".status")
    echo "deployment_satus: $deployment_satus"

    if [[ "$deployment_satus" == "Resolved-"* ]]; then
      echo "The Deployment is completed"
      is_development_complete=true
      break
    elif [[ "$deployment_satus" == *"Error"* ]]; then
      echo "Deployment Error"
      is_development_error=true
      break
    else

      ((wait_time_elapsed += $WAIT_INTERVAL_TIME))
    fi

    echo "is_development_complete: $is_development_complete"
    echo "is_development_error: $is_development_error"
    echo "wait_time_elapsed: $wait_time_elapsed"
  done

  echo "Deployment Status: $deployment_satus"

  if [[ "$deployment_satus" == *"Error"* || "$deployment_satus" == *"Rejected"* ]]; then
    abortDeployment
  elif [[ "$deployment_satus" == "Resolved-"* ]]; then
    echo "***************Deployment Completed Successfully****************"
  else
    echo "#############Deployment is Not Completed, Check the status#############"
  fi

}

# Main Script
echo "Updating the pipeline $PEGA_PIEPLINE_ID with PEGA_PROD_NAME: $PEGA_PROD_NAME and PEGA_PROD_VERSION:$PEGA_PROD_VERSION"
updatePipelineData
# echo "Triggering pipeline for $PEGA_PIEPLINE_ID"
# triggerDeployment
# echo "deploymentId: $deploymentId"

# echo "Wait For Deployment to complete"
# waitForDeploymentToComplete
