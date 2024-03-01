using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents.DTOs;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.DwellersEvents.Domain.Entites;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.DwellerEvents.GetAllEvents
{
    public class GetAllEventsQueryHandler(IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        : IQueryHandler<GetAllEventsQuery, GetAllEventsResult>
    {
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository = dwellerEventsQueryRepository;


        public async Task<DwellerResponse<GetAllEventsResult>> Handle
            (GetAllEventsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetAllEventsResult> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(query.DwellingId);
            if (eventList == null)
                return await response.ErrorResponse("No upcoming events can be found.");

            var listOfDtos = new List<ListEventDto>();
            foreach (DwellerEvent dwellerEvent in eventList)
            {
                var dto = new ListEventDto(dwellerEvent.Id, dwellerEvent.Title,
                    dwellerEvent.Description, dwellerEvent.EventDate.ToShortDateString());
                listOfDtos.Add(dto);
            }

            return await response.SuccessResponse(
                new(ListOfEvents: listOfDtos));
        }
    }
}
