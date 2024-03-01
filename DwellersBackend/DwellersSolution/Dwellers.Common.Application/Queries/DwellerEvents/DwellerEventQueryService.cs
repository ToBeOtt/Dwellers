using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.DwellerEvents
{
    public class DwellerEventQueryService
    {
        private readonly ILogger<DwellerEventQueryService> _logger;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;

        public DwellerEventQueryService(
            ILogger<DwellerEventQueryService> logger,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        {
            _logger = logger;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
        }

        public async Task<DwellerResponse<ICollection<DwellerEvent>>> FetchAllEvents
            (Guid houseId)
        {
            DwellerResponse<ICollection<DwellerEvent>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(houseId);
            if (eventList == null)
                return await response.ErrorResponse
                           ("No events found or registered.");

            return await response.SuccessResponse(eventList);
        }
    }
}


