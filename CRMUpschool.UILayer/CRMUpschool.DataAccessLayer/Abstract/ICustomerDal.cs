// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRMUpschool.EntityLayer.Concrete;

namespace CRMUpschool.DataAccessLayer.Abstract
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        ////CRUD
        //void Insert(Customer customer);
        //void Delete(Customer customer);
        //void Update(Customer customer);
        //List<Customer> GetList();//Listeyi getir
        //Customer GetById(int id);//id ye göre getir
    }
}
