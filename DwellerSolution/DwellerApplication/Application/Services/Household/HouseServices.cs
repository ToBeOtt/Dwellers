using DwellerApplication.Application.Interfaces;
using DwellerApplication.Core.Helpers;
using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;

namespace DwellerApplication.Application.Services.Household
{
    public class HouseServices
    {
        private readonly IHouseRepository _houseRepository;

        public HouseServices(IHouseRepository houseRepository)
        {
             _houseRepository = houseRepository;
        }

        public async Task<House> AddHouse(string housename, string houseDescription, string InvitationCode)
        {
            House house = new House();
            house.Name = housename;
            house.Description = houseDescription;
            house.InvitationCode = InvitationCode;

            if(!await _houseRepository.AddHouse(house))
            {
                throw new NullReferenceException(nameof(house));
            }
            return house;
        }

        public async Task<OperationResult<HouseUser>> AddHouseUser(House house, AppUser user)
        {
            HouseUser houseUser = new();
            houseUser.House = house;
            houseUser.AppUser = user;


            if (!await _houseRepository.AddHouseUser(houseUser))
            {
                return new OperationResult<HouseUser>
                {
                    Outcome = OperationOutcome.Failure,
                    ErrorMessage = "User could not be linked to household"
                };
            }
            return new OperationResult<HouseUser>
            {
                Outcome = OperationOutcome.Success,
                Value = houseUser
            };
        }
    }

}
