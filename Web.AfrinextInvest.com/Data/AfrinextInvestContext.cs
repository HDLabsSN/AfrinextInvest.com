using Microsoft.EntityFrameworkCore;

namespace Web.AfrinextInvest.com.Models
{
    public class AfrinextInvestContext : DbContext
    {
        public AfrinextInvestContext (DbContextOptions<AfrinextInvestContext> options)
            : base(options)
        {
        }

        public DbSet<Projets> Projets { get; set; }

        public DbSet<PartSociale> PartSociale { get; set; }
    }
}
