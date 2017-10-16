using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Identity
{
    public class User : IdentityUser
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Bio { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDerniereConnexion { get; set; }

        public virtual ICollection<Projet> Projets { get; set; }
    }
}
