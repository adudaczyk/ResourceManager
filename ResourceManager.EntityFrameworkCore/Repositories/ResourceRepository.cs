using Microsoft.EntityFrameworkCore;
using ResourceManager.EntityFrameworkCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class ResourceRepository : GenericRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }

        public async Task<Resource> GetResourceByGuid(string guid)
        {
            return await _dbSet.Where(x => x.Guid.ToString() == guid).FirstOrDefaultAsync();
        }
    }
}
