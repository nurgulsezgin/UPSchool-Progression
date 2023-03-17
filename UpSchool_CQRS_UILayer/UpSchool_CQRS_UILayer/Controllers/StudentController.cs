// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;

using UpSchool_CQRS_UILayer.CQRS.Commands.StudentCommands;
using UpSchool_CQRS_UILayer.CQRS.Handlers.StudentHandlers;

namespace UpSchool_CQRS_UILayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;

        public StudentController(CreateStudentCommandHandler createStudentCommandHandler)
        {
            _createStudentCommandHandler = createStudentCommandHandler;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(CreateStudentCommand command)
        {
            _createStudentCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
