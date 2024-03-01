using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.Offerings.DTOs;
using Dwellers.Common.Application.Contracts.Results.Offerings.DwellerItems;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Offerings.DwellerItems.GetAllDwellerItems
{
    public class GetAllDwellerItemsQueryHandler(IDwellerItemQueryRepository dwellerItemQueryRepository)
        : IQueryHandler<GetAllDwellerItemsQuery, GetAllDwellerItemsResult>
    {
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository = dwellerItemQueryRepository;

        public async Task<DwellerResponse<GetAllDwellerItemsResult>> Handle
            (GetAllDwellerItemsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetAllDwellerItemsResult> response = new();

            var listOfItems = await _dwellerItemQueryRepository.GetAllDwellerItems(query.DwellingId);
            if (listOfItems == null)
                return await response.ErrorResponse("No items found or registered.");
            
            List<DwellerItemListDto> listOfDtos = [];
            foreach ( var item in listOfItems )
            {
                var intScope = Convert.ToInt32(item.ItemScope);
                var itemDto = new DwellerItemListDto(item.Id, item.Name,
                    item.IsBorrowed, intScope, item.ItemPhoto);
                listOfDtos.Add(itemDto);
            }

            return await response.SuccessResponse(
                new(ListOfItems: listOfDtos));
        }
    }
}
