using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(400)]
        public string Summary { get; set; }
        [StringLength(13)]
        public short PrepTime { get; set; }
        public short CookTime { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public string LastModified { get; set; }
        public bool LastModifiedBy { get; set; }
        public bool isVegetarian { get; set; }
        public bool isVegan { get; set; }
        public short Rating { get; set; }

        //[ForeignKey("RecipeDetails")]
        //public int RecipeDetailID { get; set; }
        public ICollection<RecipeDetail> RecipeDetails { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
