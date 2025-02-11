using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Seeds;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ShortLink> ShortLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortLink>()
                .HasIndex(l => l.ShortUrl)
                .IsUnique();

            ShortLinkSeedData.Seed(modelBuilder);
        }
    }
}
