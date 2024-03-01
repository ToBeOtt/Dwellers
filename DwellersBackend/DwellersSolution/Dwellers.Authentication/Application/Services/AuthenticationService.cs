using Dwellers.Authentication.Application.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;
using static Dwellers.Authentication.Application.Services.DTO.AuthenticationDTO;

namespace Dwellers.Authentication.Application.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            IAuthenticationRepository authenticationRepository,
            IJwtTokenRepository jwtTokenRepository,
            ILogger<AuthenticationService> logger)
        {
            _authenticationRepository = authenticationRepository;
            _jwtTokenRepository = jwtTokenRepository;
            _logger = logger;
        }


        public async Task<DwellerResponse<ProvideJwtTokenDTO>> Login
            (string email, string password, Guid houseId)
        {
            DwellerResponse<ProvideJwtTokenDTO> response = new();

            var user = await _authenticationRepository.GetUserByEmail(email);
            if (user == null)
                return await response.ErrorResponse
                        ("Invalid credentials.");

            var result = await _authenticationRepository.CheckLoginCredentials(user.UserName, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                        ("Invalid credentials.");

            var token = await _jwtTokenRepository.GenerateToken(user, houseId);

            ProvideJwtTokenDTO data = new(
                DbUser: user,
                Token: token);

            return await response.SuccessResponse(data);
        }
    }
}
