namespace Dwellers.Authentication.Contracts.Requests
{
    public record RegisterDwellerToDwellingRequest(
        Guid Invitation,
        string Email);
}