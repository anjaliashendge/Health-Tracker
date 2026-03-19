using Microsoft.EntityFrameworkCore;
using HealthTracker.Models;

namespace HealthTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<HealthEntry> HealthEntries { get; set; }
    }
}