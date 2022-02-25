using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class DbCtx
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppMovilDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppMovileDbContext"));
            });
            return services;
        }
    }
}
