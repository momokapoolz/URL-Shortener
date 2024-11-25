using Microsoft.EntityFrameworkCore;

using UserLinkService.Models;

namespace UserLinkService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserLink> UserLinks { get; set; }
    }
}
