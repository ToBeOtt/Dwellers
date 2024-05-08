using Dwellers.Common.Application.Contracts.Commands.Dwellers;
using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Requests.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.DwellerCore
{
    [ApiController]
    //[Authorize]
    [Route("dweller")]
    public class DwellerController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;
        private readonly IQueryHandlerFactory _queryHandler;

        public DwellerController(
            ICommandHandlerFactory commandHandler,
            IQueryHandlerFactory queryHandler
            )
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }


        [HttpPost("SetProfilePhoto")]
        public async Task<IActionResult> SetProfilePhoto(IFormFile profilePhoto)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new SetDwellerProfilePhotoCommand(
                DwellerId: userIdClaim.Value,
                DwellerPhoto: profilePhoto);

            var handler = _commandHandler.GetHandler<SetDwellerProfilePhotoCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            return Ok(result);
        }

        [HttpGet("GetDwellerDetails")]
        public async Task<IActionResult> GetDwellerDetails()
        {
            var userIdClaim = User.FindFirst("UserId") ?? throw new InvalidCredentialException();
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var cmd = new GetDwellerDetailsQuery(
                DwellerId: userIdClaim.Value,
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetDwellerDetailsQuery, GetDwellerDetailsResult>();
            var result = await handler.Handle(cmd, new CancellationToken());

            return Ok(result);
        }
    }
}