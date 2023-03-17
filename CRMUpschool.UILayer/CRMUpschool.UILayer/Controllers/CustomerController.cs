// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

using CRMUpschool.DataAccessLayer.Concrete;

using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Customers.ToList();
            return View(values);
        }
    }
}
