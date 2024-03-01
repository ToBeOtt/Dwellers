using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.DwellerEvents.DeleteEvent
{
    public class DeleteEventCommandHandler(ILogger<DeleteEventCommandHandler> logger,
        IDwellerEventsCommandRepository dwellerEventsCommandRepository,
        IDwellerEventsQueryRepository dwellerEventsQueryRepository) : ICommandHandler<DeleteEventCommand, DwellerUnit>
    {
        private readonly ILogger<DeleteEventCommandHandler> _logger = logger;
        private readonly IDwellerEventsCommandRepository _dwellerEventsCommandRepository = dwellerEventsCommandRepository;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository = dwellerEventsQueryRepository;

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (DeleteEventCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(cmd.EventId);

            if (!await _dwellerEventsCommandRepository.DeleteEventAsync(dwellerEvent))
                return await response.ErrorResponse("Event could not be deleted.");

            return await response.SuccessResponse(new());
        }
    }
}
