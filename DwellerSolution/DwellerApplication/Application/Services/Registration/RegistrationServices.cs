using DwellerApplication.Application.Interfaces;
using DwellerApplication.Application.Services.Household;
using DwellerApplication.Application.Services.RoleServices;
using DwellerApplication.Application.Services.User;
using DwellerApplication.Core.Helpers;
using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Data.Migrations;
using DwellerApplication.Infrastructure.Data.Repositories;
using Microsoft.Identity.Client;

namespace DwellerApplication.Application.Services.Registration
{
    public class RegistrationServices
    {
        private readonly IHouseRepository _houseRepository;
        private readonly UserServices _userServices;
        private readonly RoleService _roleServices;
        private readonly HouseServices _houseServices;

        public RegistrationServices(IHouseRepository houseRepository, UserServices userServices, 
            RoleService roleServices, HouseServices houseServices)
        {
            _houseRepository = houseRepository;
            _userServices = userServices;
            _roleServices = roleServices;
            _houseServices = houseServices;
        }

        public async Task<OperationResult<bool>> AssembleHouseWithUser
            (string houseName, string houseDesc, string username)
        {
            // Create House
            var house = await _houseServices.AddHouse(houseName, houseDesc, "kodhus123");
            if(house == null)
            {
                throw new NullReferenceException(nameof(house));
            }

            // Fetch User
            var user = await _userServices.FetchUser(username);

            // Create HouseUser
            var houseUserResult = await _houseServices.AddHouseUser(house, user);
            if(houseUserResult.Outcome == OperationOutcome.Failure)
            {
                return new OperationResult<bool>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "Houseuser could not be created"
                };
            }

            var result = await _roleServices.AssignHouseOwner(user.UserName);
            if (result.Outcome == OperationOutcome.Success)
            {
                return new OperationResult<bool>
                {
                    Outcome = OperationOutcome.Success,
                };
            }
            else
            {
                return new OperationResult<bool>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "The user could not be assigned a role"
                };
            }
        }
 

        public async Task<bool> AttachUserToHouse(string invitationCode, string username)
        {
            // Fetch User
            var user = await _userServices.FetchUser(username);

            // Find house with specific invitation.code
            var house = await _houseRepository.GetHouseByInvitation(invitationCode);
            if (house == null)
            {
                throw new NullReferenceException(nameof(house));
            }
            // Link user to specific house
            var houseUserResult = await _houseServices.AddHouseUser(house, user);
            if (houseUserResult == null)
            {
                throw new NullReferenceException(nameof(HouseUser));
            }

            // Assign role to user
            if (! await _roleServices.AssignHouseMember(user.UserName))
            {
                return false;
            }

            return true;
        } 
    }
}
