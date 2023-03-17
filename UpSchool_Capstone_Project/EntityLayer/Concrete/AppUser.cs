using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public AppUser()
        {
            this.CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public string? ImageURL { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }

        public virtual List<Favorite>? Favorites { get; set; }
    }
}
