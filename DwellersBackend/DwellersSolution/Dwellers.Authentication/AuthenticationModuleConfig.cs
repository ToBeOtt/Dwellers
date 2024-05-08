using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Application.Services;
using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Dwellers.Authentication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dwellers.Authentication
{
    public static class AuthenticationModuleConfig
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, 
            IConfiguration configuration, IWebHostEnvironment environment)
        {

            var connectionString = configuration.GetConnectionString("AuthConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            if (environment.IsDevelopment())
            { 
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }
            else
            {
                //var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                //throw new InvalidOperationException("Connection string not found.");

                services.AddDbContext<AuthDbContext>(options => options.UseNpgsql(connectionString));
            }
            
            services.AddDefaultIdentity<DbUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            // Authentication & Tokens
            services.AddAuth(configuration);

            // Other services
            services.AddHttpContextAccessor();

            //Repositories
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

            services.AddTransient<RegistrationService>();
            services.AddTransient<AuthenticationService>();

            return services;
        }


        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["SecretKey"])),
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"]
                };
            });

            services.AddTransient<IJwtTokenRepository, JwtTokenRepository>();

            return services;
        }
    }
}

