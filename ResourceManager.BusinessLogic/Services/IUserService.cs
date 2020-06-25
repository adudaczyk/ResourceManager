using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string email, string password);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(string guid);
        Task AddUser(UserDto userDto);
        Task UpdateUser(UserDto userDto);
        Task DeleteUser(string guid);
        Task VerifyEmail(string guid);
    }
}
