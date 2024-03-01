using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Authentication.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthDbContext _context;
        private readonly SignInManager<DbUser> _signInManager;

        public AuthenticationRepository(
            AuthDbContext context,
            SignInManager<DbUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<DbUser> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).SingleOrDefault();
        }

        public async Task<DbUser> GetUserById(string id)
        {
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<SignInResult> CheckLoginCredentials(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }
    }
}
