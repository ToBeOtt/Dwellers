namespace Dwellers.Common.Application.Contracts.Queries.Dwellers
{
    public record GetDwellerDetailsQuery(
         string DwellerId,
         Guid DwellingId
        );
}
