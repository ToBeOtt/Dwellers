using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.Bulletins;
using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Requests.DwellerEvents;
using Dwellers.Common.Application.Contracts.Results.Bulletins;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
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
    [Route("dashboard")]
    public class DashboardController(
      IQueryHandlerFactory queryHandler) : ControllerBase
    {
        private readonly IQueryHandlerFactory _queryHandler = queryHandler;

        [HttpGet("GetDashboardBulletins")]
        public async Task<IActionResult> GetDashboardBulletins()
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var query = new GetDashboardBulletinsQuery(Dwellingid: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetDashboardBulletinsQuery, GetDashboardBulletinsResult>();
            var result = await handler.Handle(query, new CancellationToken());
            if(!result.IsSuccess)
                return BadRequest();
            
            return Ok(result);
        }

    }
}
