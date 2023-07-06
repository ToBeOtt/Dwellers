using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;

namespace DwellerApplication.Application.Interfaces
{
    public interface IHouseRepository
    {
        Task<House> GetHouse(int id);
        Task<House> GetHouseByInvitation(string invitationCode);

        Task<AppUser> GetHouseMembers(int id);

        Task<bool> AddHouse(House house);

        Task<bool> AddHouseUser(HouseUser houseUser);
    }
}
