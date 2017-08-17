using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Web.AfrinextInvest.com.Identity
{
    public class User : IdentityUser
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Portable { get; set; }
    }
}
