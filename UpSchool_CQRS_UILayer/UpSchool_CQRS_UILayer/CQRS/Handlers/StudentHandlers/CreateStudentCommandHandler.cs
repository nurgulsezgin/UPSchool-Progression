// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using UpSchool_CQRS_UILayer.CQRS.Commands.StudentCommands;
using UpSchool_CQRS_UILayer.DAL.Context;
using UpSchool_CQRS_UILayer.DAL.Entities;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers.StudentHandlers
{
    public class CreateStudentCommandHandler
    {
        private readonly ProductContext _context;

        public CreateStudentCommandHandler(ProductContext productContext)
        {
            _context = productContext;
        }

        public void Handle(CreateStudentCommand command)
        {
            _context.Students.Add(new Student
            {
                Age = command.Age,
                Name = command.Name,
                Surname = command.Surname,
                City = command.City,
                Status = command.Status,
            });
            _context.SaveChanges();
        }
    }
}
