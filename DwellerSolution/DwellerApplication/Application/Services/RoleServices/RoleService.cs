
using DwellerApplication.Core.Models.User;
using Microsoft.AspNetCore.Identity;

namespace DwellerApplication.Application.Services.RoleServices  
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<AppUser> AssignHouseOwner(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(user, "HouseOwner");
            return user;
        }

        public async Task<AppUser> AssignHouseMember(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(user, "HouseMember");
            return user;
        }
    }
}
