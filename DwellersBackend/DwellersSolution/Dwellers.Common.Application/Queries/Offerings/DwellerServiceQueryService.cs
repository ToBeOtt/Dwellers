using Dwellers.Common.Application.Interfaces.Offerings.DwellerServices;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerServices
{
    public class DwellerServiceQueryService
    {
        private readonly ILogger<DwellerServiceQueryService> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;

        public DwellerServiceQueryService(
            ILogger<DwellerServiceQueryService> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository)
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
        }

        public async Task<DwellerResponse<DwellerService>> ProvideDwellerService(Guid houseId)
        {
            DwellerResponse<DwellerService> response = new();

            var service = await _dwellerServiceQueryRepository.GetDwellerService(houseId);
            if (service == null)
                return await response.ErrorResponse
                           ("No service could be found or registered");

            return await response.SuccessResponse(service);
        }

        public async Task<DwellerResponse<ICollection<DwellerService>>> ProvideAllDwellerServices(Guid houseId)
        {
            DwellerResponse<ICollection<DwellerService>> response = new();

            var serviceList = await _dwellerServiceQueryRepository.GetAllDwellerServices(houseId);
            if (serviceList == null)
                return await response.ErrorResponse
                        ("No services found or registered.");

            return await response.SuccessResponse(serviceList);
        }
    }
}
