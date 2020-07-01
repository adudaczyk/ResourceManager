using Microsoft.EntityFrameworkCore;
using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore
{
    public class ResourceManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceItem> ResourceItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ResourceManagerDbContext(DbContextOptions<ResourceManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
