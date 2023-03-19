// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmailController : Controller
    {
        private UserManager<AppUser> _userManager;
        public EmailController(UserManager<AppUser> usrMgr)
        {
            _userManager = usrMgr;
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
