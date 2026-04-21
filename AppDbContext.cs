using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeMVC_DB_Identitty.Models;
using PracticeMVC_DB_Identitty.Data;

namespace PracticeMVC_DB_Identitty.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) // Must be specific!
            : base(options)
        {
        }
    }
}
