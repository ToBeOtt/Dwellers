namespace Dwellers.Common.Application.Contracts.Requests.Offerings
{
    public record AddDwellerServiceRequest(
         Guid HouseId,
         string Name,
         string Description,
         string ServiceScope);
}