using Dwellers.Common.Application.Interfaces;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerServices;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.Common.Infrastructure.Repositories.Bulletins.Repositories;
using Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellers;
using Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellings;
using Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerItems;
using Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerServices;
using Dwellers.Common.Persistance.Repositories.Bulletins.Repositories;
using Dwellers.Common.Persistance.Repositories.Chats.Repositories;
using Dwellers.Common.Persistance.Repositories.DwellerEvents.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Dwellers.Common.Infrastructure
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
            IConfiguration configuration, IWebHostEnvironment environment)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
               throw new InvalidOperationException("Connection string not found.");

            if (environment.IsDevelopment())
            {
                // Use in-memory database for development
                services.AddDbContext<DwellerDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }

            else
            {
               // var connectionString = configuration.GetConnectionString("DefaultConnection") ??
               //throw new InvalidOperationException("Connection string not found.");
                services.AddDbContext<DwellerDbContext>(options => options.UseNpgsql(connectionString));
            }

            //Repositories
            services.AddTransient<IDwellerQueryRepository, DwellerQueryRepository>();
            services.AddTransient<IDwellerCommandRepository, DwellerCommandRepository>();
            services.AddTransient<IDwellingQueryRepository, DwellingQueryRepository>();
            services.AddTransient<IDwellingCommandRepository, DwellingCommandRepository>();

            services.AddTransient<IDwellerItemCommandRepository, DwellerItemCommandRepository>();
            services.AddTransient<IDwellerItemQueryRepository, DwellerItemQueryRepository>();

            services.AddTransient<IDwellerServiceCommandRepository, DwellerServiceCommandRepository>();
            services.AddTransient<IDwellerServiceQueryRepository, DwellerServiceQueryRepository>();

            services.AddTransient<IChatCommandRepository, ChatCommandRepository>();
            services.AddTransient<IChatQueryRepository, ChatQueryRepository>();

            services.AddTransient<IDwellerEventsCommandRepository, DwellerEventsCommandRepository>();
            services.AddTransient<IDwellerEventsQueryRepository, DwellerEventsQueryRepository>();

            services.AddTransient<IBulletinCommandRepository, BulletinCommandRepository>();
            services.AddTransient<IBulletinQueryRepository, BulletinQueryRepository>();

            return services;
        }
    }
}
