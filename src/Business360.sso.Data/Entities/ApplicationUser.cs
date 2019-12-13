using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
