// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.EntityLayer.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace CRMUpschool.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            var jsonResult =JsonConvert.SerializeObject(_customerService.TGetList());
            return Json(jsonResult);
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            //Veri tabanına kaydedicek
            _customerService.TInsert(customer);
            //Veri tabanına ajax işlemi ile kaydedicek
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }
        public IActionResult GetById(int CustomerID)
        {
            var values = _customerService.TGetById(CustomerID);

            var jsonValues = JsonConvert.SerializeObject(values);

            return Json(jsonValues);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerService.TGetById(id);

            _customerService.TDelete(values);

            return Json(values);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            int id=customer.CustomerID;
            _customerService.TUpdate(customer);

            var values = JsonConvert.SerializeObject(customer);

            return Json(values);
        }
    }
}
