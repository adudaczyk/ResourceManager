using Microsoft.Extensions.DependencyInjection;
using ResourceManager.BusinessLogic.Services;

namespace ResourceManager.EntityFrameworkCore
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IResourceItemService, ResourceItemService>();
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
