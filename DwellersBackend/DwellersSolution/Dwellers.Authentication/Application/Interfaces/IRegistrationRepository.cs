using Dwellers.Authentication.Domain;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Authentication.Application.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<bool> CheckNoUserExist(string email);
        Task<IdentityResult> AddUser(DbUser user, string password);
    }
}
