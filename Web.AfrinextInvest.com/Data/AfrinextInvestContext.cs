using Microsoft.EntityFrameworkCore;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Models
{
    public class AfrinextInvestContext : DbContext
    {
        public AfrinextInvestContext (DbContextOptions<AfrinextInvestContext> options)
            : base(options)
        {
        }

        public DbSet<Projet> Projets { get; set; }

        public DbSet<PartSociale> PartSociale { get; set; }

        public DbSet<SecteurActivite> SecteurActivite { get; set; }

    }
}
