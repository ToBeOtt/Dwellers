using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.DwellerEvents.AddEvent
{
    public class AddEventCommandHandler(ILogger<AddEventCommandHandler> logger,
        IDwellerEventsCommandRepository dwellerEventsCommandRepository,
        IDwellingQueryRepository dwellingQueryRepository,
        IDwellerQueryRepository dwellerQueryRepository) : ICommandHandler<AddEventCommand, DwellerUnit>
    {
        private readonly ILogger<AddEventCommandHandler> _logger = logger;
        private readonly IDwellerEventsCommandRepository _dwellerEventsCommandRepository = dwellerEventsCommandRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository = dwellingQueryRepository;
        private readonly IDwellerQueryRepository _dwellerQueryRepository = dwellerQueryRepository;

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddEventCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(cmd.DwellingId);
            var dweller = await _dwellerQueryRepository.GetDwellerByIdAsync(cmd.DwellerId);

            if(dwelling is null || dweller is null)
            {
                _logger.LogError("Entities related to event are null");
                return await response.ErrorResponse("Error fetching event.");
            }

            var dwellerEvent = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent
                (cmd.Title, cmd.Desc, dwelling, dweller, cmd.EventScope);

            if (!await _dwellerEventsCommandRepository.AddEventAsync(dwellerEvent))
                return await response.ErrorResponse("Event could not be saved to database.");

            return await response.SuccessResponse(new());
        }
    }
}
