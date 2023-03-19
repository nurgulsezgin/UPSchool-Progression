// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;

using EntityLayer.Concrete;

using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFFavoriteDal : GenericRepository<Favorite>, IFavoriteDal
    {
        public int GetFavoriteCountByRecipeId(int id)
        {
            using (var context = new RecipeContext())
            {

                return context.Favorites.Include(x => x.RecipeId == id).ToList().Count();
            }
        }
    }
}
