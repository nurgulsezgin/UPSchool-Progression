
using System;

using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public DateTime ExpireDate { get; set; }
    }
}
