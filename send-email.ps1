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
   $toEmail  

)


try{
  
   $message = new-object Net.Mail.MailMessage;
   $message.From = $username;
   write-host $buildURL;
   foreach ($email in $toEmail){
      write-host $email;
      $message.To.Add($email);
   }
  
   $message.Subject = "GitHub Notificaction"
   $message.Body = "Update the status and other details"  
   $credentials = New-Object System.Net.NetworkCredential($username, $password);
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

