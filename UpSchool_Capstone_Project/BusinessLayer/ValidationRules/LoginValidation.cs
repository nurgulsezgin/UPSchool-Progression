// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer.Concrete;

using FluentValidation;
using FluentValidation.AspNetCore;

namespace BusinessLayer.ValidationRules
{
    public class LoginValidation : AbstractValidator<AppUser>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz");

        }
    }
}
