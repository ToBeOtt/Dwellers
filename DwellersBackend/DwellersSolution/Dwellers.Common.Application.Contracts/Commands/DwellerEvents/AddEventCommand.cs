namespace Dwellers.Common.Application.Contracts.Commands.DwellerEvents
{
    public record AddEventCommand(
        string Title,
        string Desc,
        string EventScope,
        DateTime EventDate,
        string DwellerId,
        Guid DwellingId
        );
}
