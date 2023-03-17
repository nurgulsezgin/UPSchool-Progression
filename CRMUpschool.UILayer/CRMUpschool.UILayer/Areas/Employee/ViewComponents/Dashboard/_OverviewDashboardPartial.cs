// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

using CRMUpschool.DataAccessLayer.Concrete;

using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Areas.Employee.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.EmployeeCount = context.Employees.Count();
                ViewBag.EmployeeGenderWomanCount = context.Users.Where(x => x.Gender == "Kadın").Count();
                int id = context.Users.Max(x => x.Id);
                ViewBag.LastUser = context.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.SurName).FirstOrDefault();
            }
            return View();
        }
    }
}
