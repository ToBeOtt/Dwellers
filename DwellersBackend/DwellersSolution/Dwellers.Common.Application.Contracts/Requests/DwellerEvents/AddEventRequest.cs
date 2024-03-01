namespace Dwellers.Common.Application.Contracts.Requests.DwellerEvents
{
    public record AddEventRequest(
     string Title,
     string Desc,
     DateTime EventDate,
     string EventScope);
}
