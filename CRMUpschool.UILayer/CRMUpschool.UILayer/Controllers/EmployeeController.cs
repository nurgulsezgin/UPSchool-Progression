// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;

using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.BusinessLayer.ValidationRules;
using CRMUpschool.EntityLayer.Concrete;

using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRMUpschool.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;//cTRL + . GENERATE CONSTRUCTOR
        private readonly ICategoryServices _categoryService; //Sayfa yüklendiğinde gelsin

        public EmployeeController(IEmployeeService employeeService, ICategoryServices categoryServices)
        {
            _employeeService = employeeService;
            _categoryService = categoryServices;
        }

        public IActionResult Index()
        {
            //var values=_employeeService.TGetList();
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            ValidationResult result = validationRules.Validate(employee); //using FluentValidation.Results; kullanmaya dikkat edin yanlış gelmemesi için
            if (result.IsValid)
            {

                _employeeService.TInsert(employee);
                return RedirectToAction("ExcelStatic");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public IActionResult DeleteEmployee(int id)
        {
            var values = _employeeService.TGetById(id);
            _employeeService.TDelete(values);
            return RedirectToAction("ExcelStatic");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _employeeService.TChangeEmployeeStatusToTrue(id);
            return RedirectToAction("ExcelStatic");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _employeeService.TChangeEmployeeStatusToFalse(id);
            return RedirectToAction("ExcelStatic");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var values = _employeeService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)//Direkt olarak erişim yerine modeldeki classlarda çalışılabiliniyor İlerde onunla yapılacak
        {
            var values = _employeeService.TGetById(employee.EmployeeID);
            employee.EmployeeStatus = values.EmployeeStatus;//default false gelsin ilk oluştuğunda deimiz için burada düzeltiyoruz
            _employeeService.TUpdate(employee);
            return RedirectToAction("ExcelStatic");
        }
    }
}
