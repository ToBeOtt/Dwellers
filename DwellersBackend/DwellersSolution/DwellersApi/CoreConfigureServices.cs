using DwellersApi.Common.Mapping;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using System.Text.Json.Serialization;

namespace DwellersApi
{
    public static class CoreConfigureServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Attach serilog
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                    .Build();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .ReadFrom.Configuration(configuration)
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // My current frontend developing port
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Enables backend to receive images from frontend
            services.AddControllers();
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
                options.ValueLengthLimit = Int32.MaxValue;
                options.MultipartBodyLengthLimit = Int64.MaxValue;
            });


            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            // Ignore circular reference looping in EF core with JSON.
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            //services.AddMappings();

            return services;
        }


    }
}


