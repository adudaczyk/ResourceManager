using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }
    }
}
