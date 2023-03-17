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
    public interface ICategoryDal : IGenericDal<Category>
    {

        ////CRUD
        //void Insert(Category category);
        //void Delete(Category category);
        //void Update(Category category);
        //List<Category> GetList();//Listeyi getir
        //Category GetById(int id);//id ye göre getir
    }
}
