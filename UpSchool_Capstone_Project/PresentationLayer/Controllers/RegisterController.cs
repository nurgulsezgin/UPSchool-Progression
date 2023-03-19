// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using System;

using EntityLayer.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using PresentationLayer.Models;

namespace PresentationLayer.Controllers
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

            if (ModelState.IsValid)
            {

                AppUser appUser = new AppUser()
                {
                    UserName = p.UserName,
                    Name = p.Name,
                    SurName = p.Surname,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                        var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = appUser.Email }, Request.Scheme);
                        EmailHelper emailHelper = new EmailHelper();
                        bool emailResponse = emailHelper.SendEmail(appUser.Email, confirmationLink);

                        if (emailResponse)
                            return RedirectToAction("Index", "Login");
                        else
                        {
                            // log email failed 
                        }
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
            return RedirectToAction("Index", "Login");
        }
    }
}
