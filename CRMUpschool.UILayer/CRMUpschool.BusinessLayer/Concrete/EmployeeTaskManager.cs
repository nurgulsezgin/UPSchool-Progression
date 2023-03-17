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
    public class EmployeeTaskManager : IEmployeeTaskService
    {
        private readonly IEmployeeTaskDal _employeeTaskDal;

        public EmployeeTaskManager(IEmployeeTaskDal employeeTaskDal)
        {
            _employeeTaskDal = employeeTaskDal;
        }

        public void TDelete(EmployeeTask t)
        {
            _employeeTaskDal.Delete(t);
        }

        public EmployeeTask TGetById(int id)
        {
            return _employeeTaskDal.GetById(id);
        }

        public List<EmployeeTask> TGetEmployeeTaskByEmployee()
        {
            return _employeeTaskDal.GetEmployeeTaskByEmployee();
        }

        public List<EmployeeTask> TGetEmployeeTaskById(int id)
        {
            return _employeeTaskDal.GetEmployeeTaskById(id);
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDal.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDal.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            _employeeTaskDal.Update(t);
        }
    }
}
