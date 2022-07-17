#!/bin/bash
echo "Starting the srcipt"

# PEGA DETAILS
PEGA_SOURCE_URL=$1
PEGA_SOURCE_USERNAME=$2
PEGA_SOURCE_PASSWORD=$3
PEGA_REST_RESPONSE_TYPE=$4
PEGA_API_ASYNC=$5
PEGA_PROD_NAME=$6
PEGA_PROD_VERSION=$7
PEGA_ARTIFACT_DIR=$8
PRPC_SERVICE_UTILS_DOWNLOAD_URL=$8
PRPC_FOLDER_NAME=$9


pwd 
curl -o $PRPC_FOLDER_NAME.zip $PRPC_SERVICE_UTILS_DOWNLOAD_URL
unzip $PRPC_FOLDER_NAME.zip -d $PRPC_FOLDER_NAME   
cd $PRPC_FOLDER_NAME
ls -ltr     
cd scripts/utils
SOURCE_FILE=source.properties
DATE_FORMAT=$(date -u +"%d%m%Y%H%M%S")
PEGA_ARCHIVE_NAME="$PEGA_PROD_NAME_$DATE_FORMAT.zip"
cp prpcServiceUtils.properties $SOURCE_FILE

echo "***********************Updating the file *****************************"
echo $PEGA_SOURCE_URL
sed -i -r "s#(pega.rest.server.url=)(.*)#\1$PEGA_SOURCE_URL#" $SOURCE_FILE
sed -i -r "s#(pega.rest.username=)(.*)#\1$PEGA_SOURCE_USERNAME#" $SOURCE_FILE
sed -i -r "s#(pega.rest.password=)(.*)#\1$PEGA_SOURCE_PASSWORD#" $SOURCE_FILE
sed -i -r "s#(pega.rest.response.type=)(.*)#\1$PEGA_REST_RESPONSE_TYPE#" $SOURCE_FILE
sed -i -r "s#(export.async=)(.*)#\1$PEGA_API_ASYNC#" $SOURCE_FILE  
sed -i -r "s#(export.productName=)(.*)#\1$PEGA_PROD_NAME#" $SOURCE_FILE
sed -i -r "s#(export.productVersion=)(.*)#\1$PEGA_PROD_VERSION#" $SOURCE_FILE     
sed -i -r "s#(export.archiveName=)(.*)#\1$PEGA_ARCHIVE_NAME#" $SOURCE_FILE
echo "**********Updating the file completed***************"      
mkdir $PEGA_ARTIFACT_DIR
ls -ltr
chmod 711 ./../bin/ant
echo "^^^^^^^^^^^^^^^^^^^^^^^Staring the export^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^"
bash ./prpcServiceUtils.sh export --propFile $SOURCE_FILE --artifactsDir ${{ github.workspace }}/$PRPC_FOLDER_NAME/scripts/utils/$PEGA_ARTIFACT_DIR
ls -ltr
cd $PEGA_ARTIFACT_DIR
ls -ltr 