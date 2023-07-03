using DwellerApplication.Application.Interfaces;
using DwellerApplication.Core.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DwellerApplication.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser> GetUserByName(string username)
        {
            return await _context.AppUsers.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }
    }
}
