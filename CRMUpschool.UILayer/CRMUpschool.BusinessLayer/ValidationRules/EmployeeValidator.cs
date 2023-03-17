﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;

using FluentValidation;

namespace CRMUpschool.BusinessLayer.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Personel adını boş geçemezsiniz!");
            RuleFor(x => x.EmployeeSurname).NotEmpty().WithMessage("Personel soyadını boş geçemezsiniz!");
            RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri giriniz!");
            RuleFor(x => x.EmployeeName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri giriniz!");
        }
    }
}
