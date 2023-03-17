// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMUpschool.EntityLayer.Concrete
{
    public class EmployeeTask
    {
        public int EmployeeTaskID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }//Tamamnlandı tamamnlanmadı yapılmakta gibi
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }//Employee sınıfı ile ilişkili olucak
        public List<EmployeeTaskDetails> EmployeeTaskDetails { get; set; }//Employeetaskdetail sınıfı ile ilişkili olucak

    }
}
