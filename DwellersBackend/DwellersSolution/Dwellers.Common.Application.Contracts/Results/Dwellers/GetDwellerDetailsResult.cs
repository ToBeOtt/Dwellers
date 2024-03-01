namespace Dwellers.Common.Application.Contracts.Results.Dwellers
{
    public record GetDwellerDetailsResult
   (
       string DwellerId,
       Guid DwellingId
   );

}
