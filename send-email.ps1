[CmdletBinding()]
param (
   [Parameter()]
   [System.String]
   $username,

   [Parameter()]
   [System.String]
   $password,

   [Parameter()]
   [System.String[]]
   $toEmail,

   [Parameter()]
   [System.String]
   $buildURL,

   [Parameter()]
   [System.String]
   $appName,

   [Parameter()]
   [System.String]
   $environment,

   [Parameter()]
   [System.String]
   $module,

   [Parameter()]
   [System.String]
   $emailReport


)


try{
  
   $message = new-object Net.Mail.MailMessage;
   $message.From = $username;
   write-host $buildURL;
   foreach ($email in $toEmail){
      write-host $email;
      $message.To.Add($email);
   }
   $buildDetails = $buildURL.Split("=");
   $buildId = $buildDetails[$buildDetails.Length -1]
   write-host $buildId;
   $message.Subject = (Get-Culture).TextInfo.ToTitleCase("Build#${buildId}: $appName-$module-$environment-Results");
   $message.isbodyhtml = $true;   
   $htmlText = Get-Content $emailReport -Raw;
   write-host $buildURL; 
   $message.Body = $htmlText.replace("{{BUILD_URL}}",$buildURL);
  
   $credentials = New-Object System.Net.NetworkCredential($Username, $Password);
   $smtp = new-object Net.Mail.SmtpClient("smtp.office365.com", "587");
   $smtp.EnableSSL = $true;
   $smtp.Credentials = $credentials;
   $smtp.send($message);
   write-host "Mail Sent";  
}
Catch
{
   $ErrorMessage = $_.Exception.Message;
   write-host $ErrorMessage 
 }

