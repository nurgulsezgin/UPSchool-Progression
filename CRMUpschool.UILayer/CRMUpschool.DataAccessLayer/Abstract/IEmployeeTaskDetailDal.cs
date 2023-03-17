// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using CRMUpschool.EntityLayer.Concrete;

namespace CRMUpschool.DataAccessLayer.Abstract
{
    public interface IEmployeeTaskDetailDal : IGenericDal<EmployeeTaskDetails>
    {
        List<EmployeeTaskDetails> GetEmployeeTaskDetailById(int id);
    }
}
