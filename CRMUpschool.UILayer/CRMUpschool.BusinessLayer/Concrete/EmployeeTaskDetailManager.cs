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
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }

        public void TDelete(EmployeeTaskDetails t)
        {
            _employeeTaskDetailDal.Delete(t);
        }

        public EmployeeTaskDetails TGetById(int id)
        {
            return _employeeTaskDetailDal.GetById(id);
        }

        public List<EmployeeTaskDetails> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetails> TGetList()
        {
            return _employeeTaskDetailDal.GetList();
        }

        public void TInsert(EmployeeTaskDetails t)
        {
            _employeeTaskDetailDal.Insert(t);
        }

        public void TUpdate(EmployeeTaskDetails t)
        {
            _employeeTaskDetailDal.Update(t);
        }
    }
}
