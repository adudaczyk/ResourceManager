using ResourceManager.BusinessLogic.Models;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public interface IAuthService
    {
        Task <AuthenticateResponse> Authenticate(string email, string password, string ipAddress);
        Task<AuthenticateResponse> RefreshToken(string token, string ipAddress);
        Task<bool> RevokeToken(string token, string ipAddress);
    }
}
