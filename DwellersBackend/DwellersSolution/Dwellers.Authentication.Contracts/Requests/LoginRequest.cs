namespace Dwellers.Authentication.Contracts.Requests
{
    public record LoginRequest(
         string Email,
         string Password
        );
}
