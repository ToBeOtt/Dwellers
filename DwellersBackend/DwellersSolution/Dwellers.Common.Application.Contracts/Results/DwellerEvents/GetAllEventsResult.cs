using Dwellers.Common.Application.Contracts.Results.DwellerEvents.DTOs;

namespace Dwellers.Common.Application.Contracts.Results.DwellerEvents
{
    public record GetAllEventsResult(
        ICollection<ListEventDto> ListOfEvents
        );
}
