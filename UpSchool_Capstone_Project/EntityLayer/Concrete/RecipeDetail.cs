// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RecipeDetail
    {
        public int RecipeDetailID { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string MakingDetails { get; set; }
        public ICollection<RecipeIngredient> Ingredents { get; set; }
    }
}
