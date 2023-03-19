// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Abstract;

using DataAccessLayer.Abstract;

using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RecipeManager : IRecipeService
    {
        IRecipeDal _recipeDal;

        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        public void TDelete(Recipe t)
        {
            _recipeDal.Delete(t);
        }

        public Recipe TGetById(int id)
        {
            return _recipeDal.GetById(id);
        }

        public List<Recipe> TGetList()
        {
            return _recipeDal.GetList();
        }

        public void TInsert(Recipe t)
        {
            _recipeDal.Insert(t);
        }

        public void TUpdate(Recipe t)
        {
            _recipeDal.Update(t);
        }
    }
}
