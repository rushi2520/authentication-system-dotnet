using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PracticeMVC_DB_Identitty.Models
{
    public class PracticeMVCDBContext : DbContext
    {
        public PracticeMVCDBContext(DbContextOptions<PracticeMVCDBContext> options) // Must be specific!
            : base(options)
        {
        }


        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Courses> Coursess { get; set; }
        public virtual DbSet<Fees> Feess { get; set; }
    }
}
