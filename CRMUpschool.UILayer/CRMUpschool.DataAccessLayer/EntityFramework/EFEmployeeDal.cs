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
    public class EFEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public List<Employee> GetEmployeesByCategory()
        {
            using (var context = new Context())
            {
                return context.Employees.Include(x => x.Category).ToList();
            }
        }

        void IEmployeeDal.ChangeEmployeeStatusToFalse(int id)
        {
            using (var context=new Context())//parametre verip tek bir method da yapabilirdik Birçok farklı algoritma kurulabilir
            {
                var values =context.Employees.Find(id);
                values.EmployeeStatus = false;
                context.SaveChanges();
            }
        }

        void IEmployeeDal.ChangeEmployeeStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.Employees.Find(id);
                values.EmployeeStatus = true;
                context.SaveChanges();//Update methodunuda çağırabilirdik aynı işlem olurdu
            }
        }
    }
}
