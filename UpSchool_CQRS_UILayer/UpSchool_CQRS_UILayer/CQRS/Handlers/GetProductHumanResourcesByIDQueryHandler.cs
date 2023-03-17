// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using UpSchool_CQRS_UILayer.CQRS.Queries.ProductQueries;
using UpSchool_CQRS_UILayer.CQRS.Results.ProductResults;
using UpSchool_CQRS_UILayer.DAL.Context;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers
{
    public class GetProductHumanResourcesByIDQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductHumanResourcesByIDQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public GetProductHumanResourcesByIDResult Handle(GetProductHumanResourcesByIDQuery query) {

            var values = _productContext.Products.Find(query.ID);
            return new GetProductHumanResourcesByIDResult
            {
                ProductID = values.ProductID,
                Brand = values.Brand,
                Name = values.Name,
                SalePrice = values.SalePrice
            };
        }
    }
}
