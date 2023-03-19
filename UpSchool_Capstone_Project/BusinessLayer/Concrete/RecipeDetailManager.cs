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
    public class RecipeDetailManager : IRecipeDetailService
    {
        IRecipeDetailDal _recipeDetailDal;

        public RecipeDetailManager(IRecipeDetailDal recipeDetailDal)
        {
            _recipeDetailDal = recipeDetailDal;
        }

        public void TDelete(RecipeDetail t)
        {
            _recipeDetailDal.Delete(t);
        }

        public RecipeDetail TGetById(int id)
        {
            return _recipeDetailDal.GetById(id);
        }

        public List<RecipeDetail> TGetList()
        {
            return _recipeDetailDal.GetList();
        }

        public void TInsert(RecipeDetail t)
        {
            _recipeDetailDal.Insert(t);
        }

        public void TUpdate(RecipeDetail t)
        {
            _recipeDetailDal.Update(t);
        }
    }
}
