using Dwellers.Common.Application.Contracts.Results.Offerings.DTOs;

namespace Dwellers.Common.Application.Contracts.Results.Offerings.DwellerItems
{

   
    public record GetAllDwellerItemsResult(
       List<DwellerItemListDto> ListOfItems);

}