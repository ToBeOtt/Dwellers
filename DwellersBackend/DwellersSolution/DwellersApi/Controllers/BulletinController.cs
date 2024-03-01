using Dwellers.Common.Application.Contracts.Commands.Bulletins;
using Dwellers.Common.Application.Contracts.Queries.Bulletins;
using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.Bulletins;
using Dwellers.Common.Application.Contracts.Results.DwellerEvents;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;
using static Dwellers.Common.Application.Contracts.Requests.Bulletins.BulletinRequests;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers
{

    [ApiController]
    [Route("bulletin")]
    public class BulletinController(
      ICommandHandlerFactory commandHandler, IQueryHandlerFactory queryHandler) : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler = commandHandler;
        private readonly IQueryHandlerFactory _queryHandler = queryHandler;

        // DWELLER-ITEMS
        [HttpPost("AddBulletinItem")]
        public async Task<IActionResult> AddBulletinPost(AddBulletinRequest request)
        {
            var dwellerId = User.FindFirst("UserId");

            if (dwellerId is null)
                throw new ArgumentNullException(nameof(dwellerId));
            
            var cmd = new AddBulletinCommand(
                      DwellerId: dwellerId.Value,
                      Title: request.Title,
                      Text: request.Text,
                      BulletinTags: request.BulletinTags,
                      BulletinStatus: request.BulletinStatus,
                      BulletinPriority: request.BulletinPriority,
                      Visibility: request.Visibility,
                      ChosenDwellings: request.ChosenDwellings
            ); ;

            var handler = _commandHandler.GetHandler<AddBulletinCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }

        [HttpGet("GetAllBulletins")]
        public async Task<IActionResult> GetAllBulletins()
        {
            var dwellingIdClaim = User.FindFirst("HouseId");

            if (dwellingIdClaim is null)
                throw new InvalidCredentialException();

            var query = new GetAllBulletinsQuery(
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetAllBulletinsQuery, GetAllBulletinsResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }
        

    }
}