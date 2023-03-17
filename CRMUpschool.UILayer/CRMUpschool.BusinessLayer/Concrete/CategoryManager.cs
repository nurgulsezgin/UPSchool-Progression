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
    public class CategoryManager : ICategoryServices//Parametre gerkmez bir üst sınıfta zaten parametre ile kalıtım alındı
    {
        //abstract türünde bir değere ihtiyacımız
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //DepencyInjection nedir
        //Bagımlılıkları minimize etmek için kullanıyoruz

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
            //Buraya çok fazla şart yazmak yerine yapabileceğimiz bir sürü kütühaneler var Rule Fromlar gibi mesela Fluent Validation gibi kullanacagımızdan bir tanesi
            //if (t.CategoryName != null && t.CategoryName.Length >= 5 && t.CategoryDescription.StartsWith("A"))
            //{
            //    _categoryDal.Insert(t);
            //}
            //else
            //{
            //    //Error message
            //}

        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
