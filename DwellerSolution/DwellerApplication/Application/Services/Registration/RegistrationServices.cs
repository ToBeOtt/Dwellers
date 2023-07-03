using DwellerApplication.Application.Interfaces;
using DwellerApplication.Application.Services.Common;
using DwellerApplication.Application.Services.User;
using DwellerApplication.Core.Models;
using DwellerApplication.Infrastructure.Data.Repositories;
using static DwellerApplication.Application.Services.Common.ErrorServices;
using static DwellerApplication.Areas.Identity.Pages.Account.IndexModel;

namespace DwellerApplication.Application.Services.Registration
{
    public class RegistrationServices
    {
        private readonly IHouseRepository _houseRepository;
        private readonly UserServices _userServices;

        public RegistrationServices(IHouseRepository houseRepository, UserServices userServices)
        {
            _houseRepository = houseRepository;
            _userServices = userServices;
        }

        public async Task<OperationResult<bool>> AssembleHouseWithUser
            (string houseName, string houseDesc, string username)
        {
            // Create House
            House house= new House();
            house.Name = houseName;
            house.Description = houseDesc;

            // Fetch User
            var user = await _userServices.FetchUser(username);

            if (!await _houseRepository.AddHouse(house))
            {
                return new OperationResult<bool>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "House object could not be added to database"
                };
            }

            // Create House
            HouseUser houseUser = new();
            houseUser.House = house;
            houseUser.AppUser = user;

            if(!await _houseRepository.AddHouseUser(houseUser))
            {
                return new OperationResult<bool>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "User could not be linked to household"
                };
            }

            return new OperationResult<bool>
            {
                Outcome = OperationOutcome.Success,
            };
        }
    }
}
