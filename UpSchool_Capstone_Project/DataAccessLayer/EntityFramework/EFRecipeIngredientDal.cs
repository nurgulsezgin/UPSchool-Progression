// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFRecipeIngredientDal : GenericRepository<RecipeIngredient>, IRecipeIngredientDal
    {
    }
}
