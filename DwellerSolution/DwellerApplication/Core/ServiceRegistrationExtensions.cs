using DwellerApplication.Application.Interfaces;
using DwellerApplication.Application.Services.Household;
using DwellerApplication.Application.Services.Registration;
using DwellerApplication.Application.Services.RoleServices;
using DwellerApplication.Application.Services.User;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Infrastructure.Data;
using DwellerApplication.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace DwellerApplication.Core
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            /* This is purely for being keeping program.cs cleaner. */
             
        // Register core services
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(x => {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register application services
            services.AddScoped<RegistrationServices>();
            services.AddScoped<UserServices>();
            services.AddScoped<HouseServices>();
            services.AddScoped<RoleService>();
            services.AddScoped<SeedUserData>();
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Register infrastructure services
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
