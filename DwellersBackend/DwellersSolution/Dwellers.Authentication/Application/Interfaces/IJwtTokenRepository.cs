using Dwellers.Authentication.Domain;
using System.Security.Claims;

namespace Dwellers.Authentication.Application.Interfaces
{
    public interface IJwtTokenRepository
    {
        Task<string> GenerateToken(DbUser user, Guid houseId);
        Task<ClaimsPrincipal> ValidateToken(string token);
    }
}
