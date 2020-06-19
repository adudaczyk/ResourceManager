using ResourceManager.EntityFrameworkCore.Models;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByGuid(string guid);
    }
}
