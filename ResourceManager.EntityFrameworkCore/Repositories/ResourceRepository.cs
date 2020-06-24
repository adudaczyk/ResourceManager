using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class ResourceRepository : GenericRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }
    }
}
