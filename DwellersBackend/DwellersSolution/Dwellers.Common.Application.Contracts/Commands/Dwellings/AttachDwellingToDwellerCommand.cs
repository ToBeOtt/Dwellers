namespace Dwellers.Common.Application.Contracts.Commands.Dwellings
{
    public record AttachDwellingToDwellerCommand(
       string Name,
       string Description,
       string Email);

}