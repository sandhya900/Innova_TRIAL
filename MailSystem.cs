using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Innova_TRIAL
{
    public class MailSystem
    {


        public bool SendMail(string name, string emailid, string verificationcode)
        {
            var body = "<p>Email From: {0} , Hi ({1})</p><p>verification code : {2}</p><p>{3}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(emailid));  // replace with valid value 
            message.From = new MailAddress("sender@outlook.com");  // replace with valid value
            message.Subject = "Veficationcode from Innova";
            message.Body = string.Format(body, "innova", name ,verificationcode, message);
            message.IsBodyHtml = true;
            bool isSuccess = false;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "user@outlook.com",  // replace with valid value , also can take from configuration file
                    Password = "password"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                isSuccess = true;
            }

            return isSuccess;
        }
    }
}