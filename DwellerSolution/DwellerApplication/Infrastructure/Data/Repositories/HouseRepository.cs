using DwellerApplication.Application.Interfaces;
using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Infrastructure.Data;

namespace DwellerApplication.Infrastructure.Data.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext _context;

        public HouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHouse(House house)
        {
            _context.Houses.Add(house);
            return Save();

        }

        public async Task<bool> AddHouseUser(HouseUser houseUser)
        {
            _context.HouseUsers.Add(houseUser);
            return Save();
        }

        Task<House> IHouseRepository.GetHouse(int id)
        {
            throw new NotImplementedException();
        }

        Task<AppUser> IHouseRepository.GetHouseMembers(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}