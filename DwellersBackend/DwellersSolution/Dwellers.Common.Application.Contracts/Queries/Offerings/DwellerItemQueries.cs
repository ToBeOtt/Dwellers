namespace Dwellers.Common.Application.Contracts.Queries.Offerings
{
    public record GetDwellerItemQuery(
          Guid ItemId
          );

    public record GetAllDwellerItemsQuery(
          Guid DwellingId
          );
}