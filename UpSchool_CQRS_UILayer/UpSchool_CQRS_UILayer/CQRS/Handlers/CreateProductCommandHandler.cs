// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using UpSchool_CQRS_UILayer.CQRS.Commands.ProductCommands;
using UpSchool_CQRS_UILayer.DAL.Context;

namespace UpSchool_CQRS_UILayer.CQRS.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly ProductContext _productContext;

        public CreateProductCommandHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public void Handle(CreateProductCommand command)
        {
            _productContext.Products.Add(new DAL.Entities.Product
            {
                Name = command.Name,
                Brand = command.Brand,
                Cost = command.Cost,
                Stock = command.Stock,
                Tax = command.Tax,
                Size = command.Size,
                PurchasePrice = command.PurchasePrice,
                SalePrice = command.SalePrice,
                ProduceOfDate = command.ProduceOfDate,
                EndOfTime = command.EndOfTime,
                Status = command.Status
            });
        }
    }
}
