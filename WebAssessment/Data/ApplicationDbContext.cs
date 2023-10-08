using Microsoft.EntityFrameworkCore;

namespace WebAssessment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserDetails> Users { get; set; }
    }

}
