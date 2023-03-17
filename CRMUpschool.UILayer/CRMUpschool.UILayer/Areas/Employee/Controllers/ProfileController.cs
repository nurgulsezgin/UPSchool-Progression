// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;
using CRMUpschool.UILayer.Areas.Employee.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfile userEditProfile = new()
            {
                Name = values.Name,
                Surname = values.SurName,
                PhoneNumber = values.PhoneNumber,
                Email = values.Email,
            };
            return View(userEditProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfile p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;//Benzersiz isimler oluşturmak için
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);//kaydedeceği konum, okuma yazma gibi rol
                await p.Image.CopyToAsync(stream);
                user.ImageURL = imageName;
            }

            user.Name = p.Name;
            user.SurName = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.Email = p.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ExcelStatic", "Login");
            }
            return View();
        }
    }
}
