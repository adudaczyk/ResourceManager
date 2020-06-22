using ResourceManager.EntityFrameworkCore.Models;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public interface IResourceItemRepository : IGenericRepository<ResourceItem>
    {
        Task<ResourceItem> GetResourceItemByGuid(string guid);
    }
}
