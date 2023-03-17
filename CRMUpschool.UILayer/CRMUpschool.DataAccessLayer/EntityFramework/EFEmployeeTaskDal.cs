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

using Microsoft.EntityFrameworkCore;

namespace CRMUpschool.DataAccessLayer.EntityFramework
{
    public class EFEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            //include işlemi
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AppUser).ToList();
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using (var context = new Context())
            {
                return context.EmployeeTasks.Where(x => x.AppUserId == id).ToList();
            }
        }
    }
}
