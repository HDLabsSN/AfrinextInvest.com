using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Web.AfrinextInvest.com.Identity
{
    public class Role: IdentityRole
    {
        public string Description { get; set; }
    }
}
