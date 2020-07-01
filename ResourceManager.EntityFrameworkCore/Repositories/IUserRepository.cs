using ResourceManager.EntityFrameworkCore.Models;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByRefreshToken(string token);
    }
}
