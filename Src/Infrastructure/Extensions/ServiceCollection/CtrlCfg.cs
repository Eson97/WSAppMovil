using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class CtrlCfg
    {
        public static IServiceCollection AddControllersExtend(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalValidationFilterAttribute>();

            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
