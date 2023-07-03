using DwellerApplication.Core.Models.User;
using DwellerApplication.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DwellerApplicationApplication.Core.Models.User;

namespace DwellerApplication.Application.Services.RoleServices
{
//    public class SeedUserData
//    {
//        private readonly ILogger<SeedUserData> _logger;
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<AppUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public SeedUserData(ILogger<SeedUserData> logger, ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            _logger = logger;
//            _context = context;
//            _userManager = userManager;
//            _roleManager = roleManager;
//        }

//        public async Task SeedAsync()
//        {
//            try
//            {
//                await TrySeedAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An error occurred while seeding the database.");
//                throw;
//            }
//        }

//        public async Task TrySeedAsync()
//        {
//            HouseOwner ownerRole = new HouseOwner();

//            if (_roleManager.Roles.All(r => r.Name != ownerRole.Name))
//            {
//                await _roleManager.CreateAsync(ownerRole);
//            }

//            // Add new hardcoded owners
//            List<string> houseOwners = new List<string>();
//            houseOwners.Add("tobias@mail.com");


//            foreach (var owner in houseOwners)
//            {
//                var houseowner = new AppUser { UserName = owner, Email = owner };

//                if (_userManager.Users.All(u => u.UserName != houseowner.UserName))
//                {
//                    await _userManager.CreateAsync(houseowner, "Owner1!"); // Sets password for admin
//                    if (!string.IsNullOrWhiteSpace(ownerRole.Name))
//                    {
//                        await _userManager.AddToRolesAsync(houseowner, new[] { ownerRole.Name });
//                    }
//                }
//            }

//        }

//        public async Task SeedUsersAsync()
//        {
//            try
//            {
//                await TrySeedUsersAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An error occurred while seeding the database.");
//                throw;
//            }
//        }
//        public async Task TrySeedUsersAsync()
//        {
//            if (await _userManager.FindByEmailAsync("sallad@mail.com") == null)
//            {
//                var user = new AppUser { UserName = "sallad@mail.com", Email = "sallad@mail.com", Id = "00000000-0000-0000-0000-000000000001" };
//                await _userManager.CreateAsync(user, "User1!");
//            }

//            if (await _userManager.FindByEmailAsync("aubergine@mail.com") == null)
//            {
//                var user = new AppUser { UserName = "aubergine@mail.com", Email = "aubergine@mail.com", Id = "00000000-0000-0000-0000-000000000002" };
//                await _userManager.CreateAsync(user, "User1!");
//            }

//            if (await _userManager.FindByEmailAsync("squash@mail.com") == null)
//            {
//                var user = new AppUser { UserName = "squash@mail.com", Email = "squash@mail.com", Id = "00000000-0000-0000-0000-000000000003" };
//                await _userManager.CreateAsync(user, "User1!");
//            }

//            if (await _userManager.FindByEmailAsync("gurka@mail.com") == null)
//            {
//                var user = new AppUser { UserName = "gurka@mail.com", Email = "gurka@mail.com", Id = "00000000-0000-0000-0000-000000000004" };
//                await _userManager.CreateAsync(user, "User1!");
//            }
//        }
//    }
}
