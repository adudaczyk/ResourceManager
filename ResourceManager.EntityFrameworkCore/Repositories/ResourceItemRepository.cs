using Microsoft.EntityFrameworkCore;
using ResourceManager.EntityFrameworkCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class ResourceItemRepository : GenericRepository<ResourceItem>, IResourceItemRepository
    {
        public ResourceItemRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }

        public async Task<ResourceItem> GetResourceItemByGuid(string guid)
        {
            return await _dbSet.Where(x => x.Guid.ToString() == guid).FirstOrDefaultAsync();
        }
    }
}
