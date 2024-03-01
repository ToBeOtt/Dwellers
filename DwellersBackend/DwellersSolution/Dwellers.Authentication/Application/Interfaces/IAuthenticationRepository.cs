using Dwellers.Authentication.Domain;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Authentication.Application.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<DbUser> GetUserByEmail(string email);
        Task<DbUser> GetUserById(string id);
        Task<SignInResult> CheckLoginCredentials(string username, string password);
    }
}
