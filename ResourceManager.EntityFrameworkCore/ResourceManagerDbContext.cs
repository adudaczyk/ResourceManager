using Microsoft.EntityFrameworkCore;
using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore
{
    public class ResourceManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ResourceManagerDbContext(DbContextOptions<ResourceManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
