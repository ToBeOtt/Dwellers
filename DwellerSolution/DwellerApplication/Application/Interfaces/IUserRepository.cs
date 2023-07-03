using DwellerApplication.Core.Models.User;

namespace DwellerApplication.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserByName(string username);
    }
}
