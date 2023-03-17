// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using UpSchool_CQRS_UILayer.CQRS.Results.ProductResults;
using UpSchool_CQRS_UILayer.DAL.Context;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers
{
    public class GetProductStorageQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductStorageQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public List<GetProductStorageQueryResult> Handle()
        {
            var values = _productContext.Products.Select(x => new GetProductStorageQueryResult
            {
                ProductID = x.ProductID,
                Name = x.Name,
                Storage = x.Storage
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
