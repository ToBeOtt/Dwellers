namespace Dwellers.Common.Application.Contracts.Requests.Offerings.DwellerItems
{
    public record AddDwellerItemRequest(
       string Name,
       string Description,
       string ItemScope);
}
