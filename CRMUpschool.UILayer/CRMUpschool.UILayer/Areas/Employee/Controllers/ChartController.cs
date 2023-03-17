// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CRMUpschool.UILayer.Models;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmentSalary> departmentSalaryList = new List<DepartmentSalary>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DepartmentChart()
        {
            departmentSalaryList.Add(new DepartmentSalary
            {
                DepartmentName = "Muhasebe",
                SalaryAvg = 10000,
            });

            departmentSalaryList.Add(new DepartmentSalary
            {
                DepartmentName = "Satış",
                SalaryAvg = 20000,
            });

            departmentSalaryList.Add(new DepartmentSalary
            {
                DepartmentName = "IT",
                SalaryAvg = 25000,
            });

            departmentSalaryList.Add(new DepartmentSalary
            {
                DepartmentName = "Pazarlama",
                SalaryAvg = 12000,
            });

            return Json(new { jsonList = departmentSalaryList });
        }
    }
}
