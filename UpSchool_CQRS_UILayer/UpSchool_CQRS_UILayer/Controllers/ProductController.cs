// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using UpSchool_CQRS_UILayer.CQRS.Commands.ProductCommands;
using UpSchool_CQRS_UILayer.CQRS.Handlers;
using UpSchool_CQRS_UILayer.CQRS.Queries.ProductQueries;
using UpSchool_CQRS_UILayer.Models;

namespace UpSchool_CQRS_UILayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductByAccounterQueryHandler _getProductByAccounterQueryHandler;
        private readonly GetProductStorageQueryHandler _getProductStorageQueryHandler;
        private readonly GetProductHumanResourcesByIDQueryHandler _getProductHumanResourcesByIDQueryHandler;
        private readonly GetProductAccounterByIDQueryHandler _getProductAccounterByIDQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        public ProductController(GetProductByAccounterQueryHandler getProductAccounterQueryHandler, GetProductStorageQueryHandler getProductStorageQueryHandler, GetProductHumanResourcesByIDQueryHandler getProductHumanResourcesByIDQueryHandler, GetProductAccounterByIDQueryHandler getProductAccounterByIDQueryHandler, CreateProductCommandHandler createProductCommandHandler)
        {
            _getProductByAccounterQueryHandler = getProductAccounterQueryHandler;
            _getProductStorageQueryHandler = getProductStorageQueryHandler;
            _getProductHumanResourcesByIDQueryHandler = getProductHumanResourcesByIDQueryHandler;
            _getProductAccounterByIDQueryHandler = getProductAccounterByIDQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductByAccounterQueryHandler.Handle();
            return View(values);
        }
        public IActionResult AccounterIndexById(int id)
        {
            var values = _getProductAccounterByIDQueryHandler.Handle(new GetProductAccounterByIDQuery(id));
            return View(values);
        }
        public IActionResult StorageIndex()
        {
            var values = _getProductStorageQueryHandler.Handle();
            return View(values);
        }
        public IActionResult GetHumanResourcesIndex(int id)
        {
            var values = _getProductHumanResourcesByIDQueryHandler.Handle(new GetProductHumanResourcesByIDQuery(id));
            return View(values);
        }
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
