using Azure;
using DwellerApplication.Application.Interfaces;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Data.Migrations;
using static DwellerApplication.Application.Services.Common.ErrorServices;

namespace DwellerApplication.Application.Services.User
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       public async Task<AppUser> FetchUser(string username)
        {
            if(username == null)
            {
                // handle error
            }

            var user = await _userRepository.GetUserByName(username);
            return user;
        }
    }
}
