// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RecipeIngredient
    {
        public int RecipeIngredientID { get; set; }
        public string? Quantity { get; set; }
        public string? Unit { get; set; }
        public string Name { get; set; }
    }
}
