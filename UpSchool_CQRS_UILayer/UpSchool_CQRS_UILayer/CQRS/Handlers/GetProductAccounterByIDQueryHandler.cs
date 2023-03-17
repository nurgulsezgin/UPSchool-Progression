// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using UpSchool_CQRS_UILayer.CQRS.Queries.ProductQueries;
using UpSchool_CQRS_UILayer.CQRS.Results.ProductResults;
using UpSchool_CQRS_UILayer.DAL.Context;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers
{
    public class GetProductAccounterByIDQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductAccounterByIDQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public GetProductAccounterByIDQueryResult Handle(GetProductAccounterByIDQuery query)
        {
            var values = _productContext.Products.Find(query.ID);
            return new GetProductAccounterByIDQueryResult
            {
                ProductID = values.ProductID,
                Brand = values.Brand,
                Decription = values.Decription,
                Name = values.Name,
                PurchasePrice = values.PurchasePrice,
                SalePrice = values.SalePrice,
                Stock = values.Stock,
                Tax = values.Tax
            };
        }
    }
}
