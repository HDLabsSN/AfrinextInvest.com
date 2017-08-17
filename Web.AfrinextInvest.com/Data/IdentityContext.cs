using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.AfrinextInvest.com.Identity;

namespace Web.AfrinextInvest.com.Data
{
    public class IdentityContext: IdentityDbContext<User, Role, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            // Rien ici
        }
    }
}
