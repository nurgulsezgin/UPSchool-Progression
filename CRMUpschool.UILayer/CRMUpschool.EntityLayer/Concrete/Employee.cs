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
    public class Employee
    {
        [Key]//PrimaryKey
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeImage { get; set; }
        //İlişkiye almak istediğim tablo burası
        public int CategoryID { get; set; }
        public Category Category { get; set; }// Diğer tarafada koleksiyonu yazıyoruz
        public bool EmployeeStatus { get; set; }//sonradan ekledik PM ile mifgrationdan güncelledik
    }
}
