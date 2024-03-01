using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Requests.Offerings;
using Dwellers.Offerings.Services.DwellerItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;


namespace DwellersApi.Controllers.Offerings
{
    [ApiController]
    [Authorize]
    [Route("dwellerServices")]
    public class DwellerServicesController(
      ICommandHandlerFactory commandHandler) : ControllerBase
    {
        private readonly DwellerItemCommandService _dwellerItemCommandService;

        private readonly ICommandHandlerFactory _commandHandler = commandHandler;

        [HttpPost("AddDwellerService")]
        public async Task<IActionResult> AddDwellerService(AddDwellerServiceRequest request)
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
                throw new InvalidCredentialException();

            var cmd = new AddDwellerServiceCommand(
                DwellingId: new Guid(houseIdClaim.Value),
                Name: request.Name,
                Description: request.Description,
                ServiceScope: request.ServiceScope);

            var handler = _commandHandler.GetHandler<AddDwellerServiceCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetAllDwellerServices")]
        public async Task<IActionResult> GetAllDwellerServices()
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
                throw new InvalidCredentialException();


            var query = new GetAllDwellerServicesQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<GetAllDwellerServicesQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
