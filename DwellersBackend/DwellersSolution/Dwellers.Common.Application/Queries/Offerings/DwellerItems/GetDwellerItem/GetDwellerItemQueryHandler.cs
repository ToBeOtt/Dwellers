using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Results.Offerings.DTOs;
using Dwellers.Common.Application.Contracts.Results.Offerings.DwellerItems;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Offerings.DwellerItems.GetDwellerItem
{
     public class GetDwellerItemQueryHandler(IDwellerItemQueryRepository dwellerItemQueryRepository)
        : IQueryHandler<GetDwellerItemQuery, GetDwellerItemResult>
    {
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository = dwellerItemQueryRepository;

        public async Task<DwellerResponse<GetDwellerItemResult>> Handle
            (GetDwellerItemQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellerItemResult> response = new();

            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(query.ItemId);
            if (dwellerItem == null)
                return await response.ErrorResponse("No item found or registered.");

            var scope = Convert.ToInt32(dwellerItem.ItemScope);

            return await response.SuccessResponse(
                new(DwellerItem: new DwellerItemDto(dwellerItem.Id, dwellerItem.Name,
                dwellerItem.Description, dwellerItem.IsBorrowed, scope, dwellerItem.ItemPhoto)));
        }
    }
}
