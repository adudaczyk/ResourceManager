﻿using Microsoft.EntityFrameworkCore;
using ResourceManager.EntityFrameworkCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
