using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.DwellersEvents.Domain.Entites;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Application.Queries.DwellerEvents.GetEvent
{
    public class GetEventQueryHandler(IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        : IQueryHandler<GetEventQuery, GetEventResult>
    {
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository = dwellerEventsQueryRepository;


        public async Task<DwellerResponse<GetEventResult>> Handle
            (GetEventQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetEventResult> response = new();

            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(query.EventId);
            if (dwellerEvent == null)
                return await response.ErrorResponse("No event found or registered.");

            return await response.SuccessResponse(
                new(dwellerEvent.Id, dwellerEvent.Title, dwellerEvent.Description, 
                dwellerEvent.EventDate, dwellerEvent.EventScope.Scope.ToString()));
        }
    }
}
