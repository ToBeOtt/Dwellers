using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Queries.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;

namespace DwellersApi.Controllers.DwellerCore
{
    [ApiController]
    [Authorize]
    [Route("dwelling")]
    public class DwellingController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;
        private readonly IQueryHandlerFactory _queryHandler;

        public DwellingController(
            ICommandHandlerFactory commandHandler,
            IQueryHandlerFactory queryHandler
            )
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet("GetConnectedDwellings")]
        public async Task<IActionResult> GetConnectedDwellings()
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var cmd = new GetConnectedDwellingsQuery(
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetConnectedDwellingsQuery, GetConnectedDwellingsResult>();
            var result = await handler.Handle(cmd, new CancellationToken());

            return Ok(result);
        }

    }
}