
using DwellerApplication.Core.Helpers;
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

        public async Task<OperationResult<AppUser>> AssignHouseOwner(string? username)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user is null)
            {
                return new OperationResult<AppUser>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "User could not be found in database"
                };
            }

            var result = await _userManager.AddToRoleAsync(user, "HouseOwner");
            if (result.Succeeded)
            {
                return new OperationResult<AppUser>
                {
                    Outcome = OperationOutcome.Success,
                    Value = user
                };
            }
            else
            {
                return new OperationResult<AppUser>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "User could not be assigned the role of house owner."
                };
            }
        }

        public async Task<bool> AssignHouseMember(string? username)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var result = await _userManager.AddToRoleAsync(user, "HouseMember");
            if (result.Succeeded)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
