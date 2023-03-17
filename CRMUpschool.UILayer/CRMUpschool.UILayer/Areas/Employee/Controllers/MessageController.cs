// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System.Threading.Tasks;
using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.EntityLayer.Concrete;
using CRMUpschool.UILayer.Areas.Employee.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MimeKit;
using MailKit.Net.Smtp;
using System;
using CRMUpschool.DataAccessLayer.Concrete;
using System.Linq;

namespace CRMUpschool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;
            m.SenderName = user.Name + " " + user.SurName;
            using (var context = new Context())
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.SurName).FirstOrDefault();
            }
            MailRequest _mailRequest = new()
            {
                SenderEmail = m.SenderEmail,
                SenderName = m.SenderName,
                ReceiverMail = m.ReceiverEmail,
                ReceiverName = m.ReceiverName,
                EmailSubject = m.MessageSubject,
                EmailContent = m.MessageContent,
            };
            bool isSendMail = await SendEmail(_mailRequest);
            if (isSendMail)
            {
                _messageService.TInsert(m);
            }
            return View();
        }
        public async Task<bool> SendEmail(MailRequest p)
        {
            try
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress(p.SenderName, p.SenderEmail);
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(p.ReceiverName, p.ReceiverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = p.EmailContent;

                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = p.EmailSubject;

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(p.SenderEmail, "passwordKey");//Change here
                client.Send(mimeMessage);
                client.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
