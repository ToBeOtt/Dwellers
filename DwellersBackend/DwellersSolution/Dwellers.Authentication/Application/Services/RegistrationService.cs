using Azure;
using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Domain;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;
using static Dwellers.Authentication.Application.Services.DTO.AuthenticationDTO;

namespace Dwellers.Authentication.Application.Services
{
    public class RegistrationService
    {
        private readonly ILogger<RegistrationService> _logger;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(
            ILogger<RegistrationService> logger,
            IRegistrationRepository registrationRepository)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
        }

        public async Task<DwellerResponse<RegistrationDTO>> Register(string email, string alias, string password)
        {
            DwellerResponse<RegistrationDTO> response = new();

            if (await _registrationRepository.CheckNoUserExist(email))
                return await response.ErrorResponse
                        ("Email taken or wrong format");

            var user = new DbUser();

            var userCreationResult = await user.CreateUser(email, alias);
            if (!userCreationResult.IsSuccess)
                return await response.ErrorResponse
                        ("Could not create user.");

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                        ("Could not create user.");

            RegistrationDTO data = new(
              DbUser: user);
            return await response.SuccessResponse(data);
        }

        public async Task<DwellerResponse<RegistrationDTO>> AttachHouseTo(string email, string alias, string password)
        {
            DwellerResponse<RegistrationDTO> response = new();

            if (await _registrationRepository.CheckNoUserExist(email))
                return await response.ErrorResponse
                        ("Duplicate email.");

            var user = new DbUser();
            var userCreationResult = await user.CreateUser(email, alias);
            if (!userCreationResult.IsSuccess)
                return await response.ErrorResponse
                        ("Could not create user.");

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                        ("Could not create user.");

            RegistrationDTO data = new(
              DbUser: user);
            return await response.SuccessResponse(data);
        }
    }
}
