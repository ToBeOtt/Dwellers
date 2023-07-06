using DwellerApplication.Application.Interfaces;
using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Infrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DwellerApplication.Infrastructure.Data.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HouseRepository> _logger;

        public HouseRepository(ApplicationDbContext context, ILogger<HouseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddHouse(House house)
        {
            try
            {
                _context.Houses.Add(house);
                return Save();
            }
            catch (NullReferenceException nEx)
            {
                _logger.LogInformation(nEx.Message);
                _logger.LogCritical(nEx.StackTrace);
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
            

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

        public async Task<House> GetHouseByInvitation(string invitationCode)
        {
           return await _context.Houses.Where(h => h.InvitationCode == invitationCode).FirstOrDefaultAsync();
        }


    }
}