// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int RecipeID { get; set; }
        public int AppUserIdID { get; set; }
        [Required(ErrorMessage = "Yorum satırını boş geçemezsiniz!")]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual Recipe Recipe { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
