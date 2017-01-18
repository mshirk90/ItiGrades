using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using BusinessObjects;

namespace EmailHelper
{
    public class Email
    {
        public static bool SendEmail(string toAddress, string subject, string body)
        {
            MailAddress to = new MailAddress(toAddress);
            EmailConfiguration config = new EmailConfiguration();
            config = config.GetByDisplayName("noreply");

            MailAddress fromAddress = new MailAddress(config.Email, config.DisplayName);
            string fromPassword = config.Password;
            string smtpHost = config.Host;
            int smtpPort = config.Port; //gmail port

            try
            {
                var smtp = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception err)
            {
                return false;
                throw;
            }

        }
    }
}