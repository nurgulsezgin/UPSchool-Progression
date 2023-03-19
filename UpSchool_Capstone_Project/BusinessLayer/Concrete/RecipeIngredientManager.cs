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
    public class RecipeIngredientManager : IRecipeIngredientService
    {
        IRecipeIngredientDal _recipeIngredientDal;

        public RecipeIngredientManager(IRecipeIngredientDal recipeIngredientDal)
        {
            _recipeIngredientDal = recipeIngredientDal;
        }

        public void TDelete(RecipeIngredient t)
        {
            _recipeIngredientDal.Delete(t);
        }

        public RecipeIngredient TGetById(int id)
        {
            return _recipeIngredientDal.GetById(id);
        }

        public List<RecipeIngredient> TGetList()
        {
            return _recipeIngredientDal.GetList();
        }

        public void TInsert(RecipeIngredient t)
        {
            _recipeIngredientDal.Insert(t);
        }

        public void TUpdate(RecipeIngredient t)
        {
            _recipeIngredientDal.Update(t);
        }
    }
}
