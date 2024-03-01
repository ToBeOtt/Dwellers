using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Authentication.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<DbUser> _userManager;

        public RegistrationRepository(AuthDbContext context, UserManager<DbUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(DbUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _context.SaveChanges();
                return result;
            }
            return result;
        }

        public async Task<bool> CheckNoUserExist(string email)
        {
            var result = await _context.Users.AnyAsync(u => u.Email == email);
            if(result.Equals(true))
                return true;
            else return false;
        }
    }
}
