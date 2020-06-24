using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class ResourceItemRepository : GenericRepository<ResourceItem>, IResourceItemRepository
    {
        public ResourceItemRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }
    }
}
