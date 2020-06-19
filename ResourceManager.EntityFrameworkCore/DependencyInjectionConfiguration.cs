using Microsoft.Extensions.DependencyInjection;
using ResourceManager.EntityFrameworkCore.Repositories;

namespace ResourceManager.EntityFrameworkCore
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
