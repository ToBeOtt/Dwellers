using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using Dwellers.Offerings.Domain.DwellerItems;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerItems
{
    public class DwellerItemCommandService
    {
        private readonly ILogger<DwellerItemCommandService> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public DwellerItemCommandService
            (ILogger<DwellerItemCommandService> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            IDwellerItemQueryRepository dwellerItemQueryRepository,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
            _dwellingQueryRepository = dwellingQueryRepository;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistItem(AddDwellerItemCommand cmd)
        {
            DwellerResponse<bool> response = new();
            var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(cmd.DwellingId);
            if (dwelling == null)
                return await response.ErrorResponse("Owner of item could not be resolved.");

            var dwellerItem = new DwellerItem(cmd.Name, cmd.Desc, dwelling, cmd.ItemScope);

            if (cmd.ItemPhoto != null)
                await dwellerItem.SetItemPhoto(cmd.ItemPhoto);

            await _dwellerItemCommandRepository.AddDwellerItem(dwellerItem);

            var establishOwnerShip = new BorrowedItem(dwelling, dwellerItem);

            if (!await _dwellerItemCommandRepository.RegisterItemStatus(establishOwnerShip))
                return await response.ErrorResponse
                            ("Ownership of item could not be established.");

            return await response.SuccessResponse();
        }

        public async Task<DwellerResponse<bool>> DeleteDwellerItem(Guid itemId)
        {
            DwellerResponse<bool> response = new();

            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (dwellerItem == null)
                return await response.ErrorResponse("Item could not be found.");


            if (!await _dwellerItemCommandRepository.RemoveDwellerItem(dwellerItem))
                return await response.ErrorResponse
                         ("Could not delete item from database.");

            return await response.SuccessResponse();
        }
    }
}
