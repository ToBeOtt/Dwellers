namespace Dwellers.Common.Application.Contracts.Commands.Offerings
{
    public record AddDwellerServiceCommand(
     string Name,
     string Description,
     string ServiceScope,
     Guid DwellingId
     );
}
