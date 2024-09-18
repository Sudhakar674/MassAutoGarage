using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace MassAutoGarage.Data
{
    public class EmailHelper
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpSection = (SmtpSection)WebConfigurationManager.GetSection("system.net/mailSettings/smtp");
                var fromAddress = new MailAddress(smtpSection.From);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add(toEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Host = smtpSection.Network.Host;
                        smtpClient.Port = smtpSection.Network.Port;
                        smtpClient.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                        smtpClient.EnableSsl = smtpSection.Network.EnableSsl;
                        smtpClient.Timeout = 1200000;
                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }






        //public void SendEmail(string to, string subject, string body)
        //{
        //    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        //    var smtpClient = new SmtpClient("mail.masssoftwares.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential("test@masssoftwares.com", "test#devpass2024"),
        //        EnableSsl = false,
        //    };

        //    var message = new MailMessage("test@masssoftwares.com", to, subject, body);
        //    smtpClient.Send(message);
        //}
    }
}