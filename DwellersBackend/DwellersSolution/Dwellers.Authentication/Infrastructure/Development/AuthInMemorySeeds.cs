using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Authentication.Infrastructure.Development
{
    public static class AuthInMemorySeeds
    {
        public static async Task<string> Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var userManager = scopedServices.GetRequiredService<UserManager<DbUser>>();
                var context = scopedServices.GetRequiredService<AuthDbContext>();
                context.Database.EnsureCreated();

                string userIdForDwellerDbContextSeed = "";

                // Check if the database has been seeded
                if (!context.Users.Any())
                {
                    var user = new DbUser
                    {
                        UserName = "test@mail.com", 
                        Email = "test@mail.com",
                        Alias = "Testaren1"
                    };

                    var result = await userManager.CreateAsync(user, "Admin1!");
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to seed user: " + result.Errors.FirstOrDefault()?.Description);
                    }
                    else
                        userIdForDwellerDbContextSeed = user.Id;
                }
                return userIdForDwellerDbContextSeed;
            }
        }
    }
}
