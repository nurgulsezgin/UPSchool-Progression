// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.DataAccessLayer.Abstract;
using CRMUpschool.DataAccessLayer.Concrete;
using CRMUpschool.DataAccessLayer.Repository;
using CRMUpschool.EntityLayer.Concrete;

namespace CRMUpschool.DataAccessLayer.EntityFramework
{
    public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public List<Announcement> ContainA()
        {
            using (var context = new Context())
            {
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;
            }
        }
    }
}
