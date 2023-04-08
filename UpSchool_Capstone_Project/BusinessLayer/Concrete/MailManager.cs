// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Mail;

using BusinessLayer.Abstract;

using DataAccessLayer.Configurations;

using Microsoft.Extensions.Options;

namespace BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        private readonly EmailConfiguration _emailsettings;

        public MailManager(IOptions<EmailConfiguration> emailsettings)
        {
            _emailsettings = emailsettings.Value;
        }

        public SmtpClient CreateMailClient()
        {

            SmtpClient client = new SmtpClient(_emailsettings.SmtpServer, _emailsettings.SmtpsPort)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_emailsettings.From, _emailsettings.Password),
                EnableSsl = true

            };
            return client;
        }
        public MailMessage CreateMailMessage(string toEmail, string subject, string body)
        {
            MailMessage mailMessage = new()
            {
                From = new MailAddress(_emailsettings.From),
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            mailMessage.To.Add(new MailAddress(toEmail));
            return mailMessage;


        }
        public bool SendMail(SmtpClient client, MailMessage message)
        {
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                //Log will be here
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        public bool ConfirmMail(string email, string confirmationLink)
        {
            string subject = "Confirm your email";
            string body = $@"<h3>Üyeliğinizi aktif etmek için aşaıdaki linke tıklayınız.</h3>
                          <p><a href='<{confirmationLink}'> LİNKE TIKLA </a></p>";

            SmtpClient client = CreateMailClient();
            MailMessage message = CreateMailMessage(email, subject, body);
            return SendMail(client, message);


        }

        public bool ResetPasswordMail(string email, string confirmationLink)
        {
            string subject = "Reset your password";
            string body = $@"<h3>Şifrenizi yenilemek için aşağıdaki linke tıklayınız.</h3>
                          <p><a href='<{confirmationLink}'> LİNKE TIKLA </a></p>";

            SmtpClient client = CreateMailClient();
            MailMessage message = CreateMailMessage(email, subject, body);
            return SendMail(client, message);
        }

        public bool WelcomeMail(string userName, string email)
        {
            string subject = "Welcome";
            string body = $@"<h3>Hoşgeldiniz.</h3>
                          <p> Sayın {userName}, Sitemize üye olduunuz için teşekkür ederiz.</p>";

            SmtpClient client = CreateMailClient();
            MailMessage message = CreateMailMessage(email, subject, body);
            return SendMail(client, message);
        }


    }
}
