// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace CRMUpschool.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>//Key olarak int ataması yapar
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
       // public string MailCode { get; set; }
        public List<EmployeeTask> EmployeeTasks { get; set; }
    }
}
