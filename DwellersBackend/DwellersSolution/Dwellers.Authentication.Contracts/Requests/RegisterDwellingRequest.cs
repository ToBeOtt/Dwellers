namespace Dwellers.Authentication.Contracts.Requests
{
    public record RegisterDwellingRequest(
        string Name,
        string Description,
        string Email);
}
