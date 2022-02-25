using Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class DbCtxFactory
    {
        public static IServiceCollection AddDbFactory(this IServiceCollection services)
        {
            services.AddScoped<Func<AppMovilDbContext>>((provider) => () => provider.GetService<AppMovilDbContext>());
            return services;
        }
    }
}
