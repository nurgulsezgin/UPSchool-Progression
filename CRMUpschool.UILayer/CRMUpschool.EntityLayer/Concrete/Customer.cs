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
    public class Customer
    {
        [Key]//Primary key Birincil anahtar olucak
        public int CustomerID { get; set; }
        //İçinde ID geçen zaten primary key oluyor?
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }
    }
}
