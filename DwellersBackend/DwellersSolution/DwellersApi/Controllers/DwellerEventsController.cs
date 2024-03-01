using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Requests.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("events")]
    public class DwellerEventsController(
      ICommandHandlerFactory commandHandler,
      IQueryHandlerFactory queryHandler) : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler = commandHandler;
        private readonly IQueryHandlerFactory _queryHandler = queryHandler;

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(AddEventRequest request)
        {
            var dwellerIdClaim = User.FindFirst("UserId");
            var dwellingIdClaim = User.FindFirst("HouseId");

            if (dwellerIdClaim is null || dwellingIdClaim is null)
                throw new InvalidCredentialException();

            var cmd = new AddEventCommand(
                Title: request.Title,
                Desc: request.Desc,
                EventDate: request.EventDate,
                EventScope: request.EventScope,
                DwellerId: dwellerIdClaim.Value,
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _commandHandler.GetHandler<AddEventCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }

        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(Guid eventId)
        {
            var query = new GetEventQuery(
                EventId: eventId);

            var handler = _queryHandler.GetHandler<GetEventQuery, GetEventResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var dwellingIdClaim = User.FindFirst("HouseId");

            if (dwellingIdClaim is null)
                throw new InvalidCredentialException();

            var query = new GetAllEventsQuery(
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetAllEventsQuery, GetAllEventsResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }

        [HttpGet("GetUpcomingEvents")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var query = new GetUpcomingEventsQuery(
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetUpcomingEventsQuery, GetUpcomingEventsResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }

        [HttpPost("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(DeleteEventRequest request)
        {

            var userIdClaim = User.FindFirst("UserId");
            var houseIdClaim = User.FindFirst("HouseId");

            if (userIdClaim is null || houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new DeleteEventCommand(
                EventId: request.EventId);

            var handler = _commandHandler.GetHandler<DeleteEventCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }
    }
}
