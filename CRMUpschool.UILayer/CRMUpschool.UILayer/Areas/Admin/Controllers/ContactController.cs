// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.DTOLayer.DTOs.ContactDTOs;
using CRMUpschool.EntityLayer.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactService.TInsert(new Contact()
                {
                    Name = model.Name,
                    Mail = model.Mail,
                    Content = model.Content,
                    Subject = model.Subject,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
