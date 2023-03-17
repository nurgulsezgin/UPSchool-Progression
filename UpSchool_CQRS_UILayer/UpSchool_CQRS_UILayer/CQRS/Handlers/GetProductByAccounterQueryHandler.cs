// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using UpSchool_CQRS_UILayer.CQRS.Results.ProductResults;
using UpSchool_CQRS_UILayer.DAL.Context;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers
{
    public class GetProductByAccounterQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductByAccounterQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public List<GetProductByAccounterQueryResult> Handle()
        {
            var values = _productContext.Products.Select(x => new GetProductByAccounterQueryResult
            {
                ProductID = x.ProductID,
                Name = x.Name,
                Stock = x.Stock,
                Brand = x.Brand,
                Tax = x.Tax,
                SalePrice = x.SalePrice,
                PurchasePrice = x.PurchasePrice
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
