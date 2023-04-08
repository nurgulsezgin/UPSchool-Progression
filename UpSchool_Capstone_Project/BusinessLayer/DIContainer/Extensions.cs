// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<IFavoriteService, FavoriteManager>();
            services.AddScoped<IFavoriteDal, EFFavoriteDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IRecipeDetailService, RecipeDetailManager>();
            services.AddScoped<IRecipeDetailDal, EFRecipeDetailDal>();

            services.AddScoped<IRecipeIngredientService, RecipeIngredientManager>();
            services.AddScoped<IRecipeIngredientDal, EFRecipeIngredientDal>();

            services.AddScoped<IRecipeService, RecipeManager>();
            services.AddScoped<IRecipeDal, EFRecipeDal>();

            services.AddScoped<IMailService, MailManager>();
        }
    }
}
