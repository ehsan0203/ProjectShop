using Microsoft.EntityFrameworkCore;
using ProjectHemid.Model.Domain;

namespace ProjectHemid.Data
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Blog> Blogs { get; set; }

    }
}
