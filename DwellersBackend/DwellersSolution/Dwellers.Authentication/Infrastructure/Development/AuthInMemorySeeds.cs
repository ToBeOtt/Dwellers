using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph.Models;

namespace Dwellers.Authentication.Infrastructure.Development
{
    public static class AuthInMemorySeeds
    {
        public static async Task<List<string>> Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var userManager = scopedServices.GetRequiredService<UserManager<DbUser>>();
                var context = scopedServices.GetRequiredService<AuthDbContext>();
                context.Database.EnsureCreated();

                List<string> userIdForDwellerDbContextSeeds = new List<string>();

                // Check if the database has been seeded
                if (!context.Users.Any())
                {
                    var dwelling1 = new DbUser
                    {
                        UserName = "test@mail.com", 
                        Email = "test@mail.com",
                        Alias = "Testaren"
                    };

                    var dwelling2 = new DbUser
                    {
                        UserName = "varg@mail.com",
                        Email = "varg@mail.com",
                        Alias = "Vargen"
                    };
                    var resultDwelling1 = await userManager.CreateAsync(dwelling1, "Admin1!");
                    if (!resultDwelling1.Succeeded)
                        throw new Exception("Failed to seed user: " + resultDwelling1.Errors.FirstOrDefault()?.Description);
                    
                    var resultDwelling2 = await userManager.CreateAsync(dwelling2, "Admin1!");
                    if (!resultDwelling2.Succeeded)
                        throw new Exception("Failed to seed user: " + resultDwelling1.Errors.FirstOrDefault()?.Description);

                    else
                    {
                        userIdForDwellerDbContextSeeds.Add(dwelling1.Id);
                        userIdForDwellerDbContextSeeds.Add(dwelling2.Id);
                    }
                        
                }
                return userIdForDwellerDbContextSeeds;
            }
        }
    }
}
