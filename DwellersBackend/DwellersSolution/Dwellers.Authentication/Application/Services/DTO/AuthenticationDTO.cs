using Dwellers.Authentication.Domain;

namespace Dwellers.Authentication.Application.Services.DTO
{
    public class AuthenticationDTO
    {
        public record ProvideJwtTokenDTO (
            DbUser DbUser,            
            string Token);

        public record RegistrationDTO(
            DbUser DbUser);
    }
}
