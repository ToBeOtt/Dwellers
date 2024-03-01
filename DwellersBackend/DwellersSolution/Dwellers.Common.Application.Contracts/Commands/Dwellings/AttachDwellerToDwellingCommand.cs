namespace Dwellers.Common.Application.Contracts.Commands.Dwellings
{
    public record AttachDwellerToDwellingCommand(
     Guid Invitation,
     string Email);
}