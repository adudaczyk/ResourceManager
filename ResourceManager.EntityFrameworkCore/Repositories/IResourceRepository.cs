using ResourceManager.EntityFrameworkCore.Models;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public interface IResourceRepository : IGenericRepository<Resource>
    {
        Task<Resource> GetResourceByGuid(string guid);
    }
}
