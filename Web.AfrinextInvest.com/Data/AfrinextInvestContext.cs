using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
