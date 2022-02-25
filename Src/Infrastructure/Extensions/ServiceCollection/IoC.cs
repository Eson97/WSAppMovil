using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Base;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class IoC
    {
        public static IServiceCollection addDepencency(this IServiceCollection services)
        {
            /* Factory y Unit Of Work */
            services.AddScoped<IDbFactory<AppMovilDbContext>, DbFactory<AppMovilDbContext>>();
            services.AddScoped<IUnitOfWork<AppMovilDbContext>, UnitOfWork<AppMovilDbContext>>();

            /* Repositorios */
            services.AddTransient<IAppRepository<AppMovilDbContext>, AppRepository>();
            services.AddTransient<IUsuarioRepository<AppMovilDbContext>, UsuarioRepository>();
            services.AddTransient<IAppVersionRepository<AppMovilDbContext>, AppVersionRepository>();
            services.AddTransient<IDescargaRepository<AppMovilDbContext>, DescargaRepository>();

            /* Servicios */
            services.AddTransient<IAppService, AppService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAppVersionService, AppVersionService>();
            services.AddTransient<IDescargaService, DescargaService>();

            return services;
        }

    }
}
