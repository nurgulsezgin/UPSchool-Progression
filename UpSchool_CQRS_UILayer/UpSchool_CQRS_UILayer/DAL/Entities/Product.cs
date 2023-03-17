// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace UpSchool_CQRS_UILayer.DAL.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public int Tax { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Cost { get; set; }
        public string Storage { get; set; }
        public string Supplier { get; set; }
        public string Decription { get; set; }
        public string SizeType { get; set; }
        public decimal Size { get; set; }
        public DateTime ProduceOfDate { get; set; }
        public DateTime EndOfTime { get; set; }
        public bool Status { get; set; }
    }
}
