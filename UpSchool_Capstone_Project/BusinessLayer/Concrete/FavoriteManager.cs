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
    public class FavoriteManager : IFavoriteService
    {
        readonly IFavoriteDal _favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }

        public void TDelete(Favorite t)
        {
            _favoriteDal.Delete(t);
        }

        public Favorite TGetById(int id)
        {
            return _favoriteDal.GetById(id);
        }

        public List<Favorite> TGetList()
        {
            return _favoriteDal.GetList();
        }

        public void TInsert(Favorite t)
        {
            _favoriteDal.Insert(t);
        }

        public void TUpdate(Favorite t)
        {
            _favoriteDal.Update(t);
        }
    }
}
