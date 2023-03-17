// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;
using CRMUpschool.UILayer.Models;

using MailKit.Net.Smtp;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using MimeKit;

namespace CRMUpschool.UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;//manager not from BL
        private readonly IConfiguration _configuration;
        private readonly RoleManager<AppRole> _roleManager;

        public RegisterController(UserManager<AppUser> userManager, IConfiguration configuration, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpModel p)
        {
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999);

            if (ModelState.IsValid)
            {

                AppUser appUser = new AppUser()
                {
                    UserName = p.UserName,
                    Name = p.Name,
                    SurName = p.Surname,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                 //   MailCode = number.ToString()
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                       // SendMail(appUser.MailCode, p.Email);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);//Hataları gösterir
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Şifreler uyuşmuyor");

                }
            }
            return View();
        }
        public void SendMail(string emailcode, string MailReceiver)
        {
            string mailKey = _configuration["MailKey"];

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "fromMail@gmail.com");//ChangeHere
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", MailReceiver);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Üyelik Kaydı";

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("fromMail@gmail.com", mailKey); //Change here
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }
        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);

            //if (user.MailCode == appUser.MailCode)
            //{
            //    user.EmailConfirmed = true;

            //    var result = await _userManager.UpdateAsync(user);

            //    await _userManager.AddToRoleAsync(user, "Employee");

            //    return RedirectToAction("Index", "Login");
            //}

            return View();
        }
    }
}
