using ManasApp.Data.Configurations;
using ManasApp.Data.Contract.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManasApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<StorageData> StorageData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocalityConfiguration());
        }
    }
}
