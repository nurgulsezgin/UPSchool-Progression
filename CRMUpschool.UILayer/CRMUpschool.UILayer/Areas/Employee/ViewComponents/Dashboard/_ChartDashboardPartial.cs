// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.ComponentModel;

using CRMUpschool.DataAccessLayer.Concrete;
using CRMUpschool.UILayer.Models;

using Microsoft.AspNetCore.Mvc;

namespace CRMUpschool.UILayer.Areas.Employee.ViewComponents.Dashboard
{
    public class _ChartDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
