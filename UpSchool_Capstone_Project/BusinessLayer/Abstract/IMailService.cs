// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMailService
    {
        SmtpClient CreateMailClient();
        MailMessage CreateMailMessage(string toEmail, string subject, string body);
        bool SendMail(SmtpClient client, MailMessage message);
        bool WelcomeMail(string userName, string email);
        bool ResetPasswordMail(string email, string confirmationLink);
        bool ConfirmMail(string email, string confirmationLink);
    }
}
