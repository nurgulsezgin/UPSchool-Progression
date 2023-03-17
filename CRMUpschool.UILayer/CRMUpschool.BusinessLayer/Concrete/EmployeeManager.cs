// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.DataAccessLayer.Abstract;
using CRMUpschool.EntityLayer.Concrete;

namespace CRMUpschool.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;//CTRL  . generate structure Yapıcımetodu geliyor

        public EmployeeManager(IEmployeeDal employeDal)
        {
            _employeeDal = employeDal;
        }

        public void TDelete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee TGetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> TGetEmployeesByCategory()
        {
            return _employeeDal.GetEmployeesByCategory();
        }

        public List<Employee> TGetList()
        {
            return _employeeDal.GetList();
        }

        public void TInsert(Employee t)
        {
            _employeeDal.Insert(t);
        }

        public void TUpdate(Employee t)
        {
            _employeeDal.Update(t);
        }

        void IEmployeeService.TChangeEmployeeStatusToFalse(int id)
        {
            _employeeDal.ChangeEmployeeStatusToFalse(id);
        }

        void IEmployeeService.TChangeEmployeeStatusToTrue(int id)
        {
            _employeeDal.ChangeEmployeeStatusToTrue(id);
        }
    }
}
