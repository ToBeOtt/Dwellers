using Dwellers.Common.Application.Queries.Chats;
using Dwellers.Offerings.Services.DwellerItems;
using Dwellers.Offerings.Services.DwellerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;

namespace Dwellers.Common.Application
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Other services
            services.AddTransient<DwellerItemCommandService>();
            services.AddTransient<DwellerItemQueryService>();

            services.AddTransient<DwellerServiceCommandService>();
            services.AddTransient<DwellerServiceQueryService>();



            // Handlers
            services.Scan(scan =>
            {
                // Scan for all assemblies that might contain handlers
                scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    // Add classes that are assignable to ICommandHandler<,>
                    .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();

                // You can chain another scan operation for IQueryHandler<,> within the same scan call
                scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    // Add classes that are assignable to IQueryHandler<,>
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });


            // SignalR
            services.AddSignalR();

            return services;
        }
    }
}
