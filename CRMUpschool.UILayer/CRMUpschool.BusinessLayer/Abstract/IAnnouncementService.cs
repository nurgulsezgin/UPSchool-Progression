// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;

namespace CRMUpschool.BusinessLayer.Abstract
{
    public interface IAnnouncementService : IGenericService<Announcement>
    {
       public List<Announcement> TContainA();
    }
}
