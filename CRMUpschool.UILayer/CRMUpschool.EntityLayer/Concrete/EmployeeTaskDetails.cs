// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMUpschool.EntityLayer.Concrete
{
    public class EmployeeTaskDetails
    {
        [Key]
        public int EmployeeTaskDetailID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeTaskID { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
