using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Requests.Offerings.DwellerItems;
using Dwellers.Common.Application.Contracts.Results.Offerings.DwellerItems;
using Dwellers.Offerings.Services.DwellerItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;


namespace DwellersApi.Controllers.Offerings
{
    [ApiController]
    [Authorize]
    [Route("dwellerItems")]
    public class DwellerItemsController(IQueryHandlerFactory queryHandlerFactory,
      ICommandHandlerFactory commandHandler) : ControllerBase
    {
        private readonly DwellerItemCommandService _dwellerItemCommandService;
        private readonly IQueryHandlerFactory _queryHandlerFactory = queryHandlerFactory;
        private readonly ICommandHandlerFactory _commandHandler = commandHandler;

        // DWELLER-ITEMS
        [HttpPost("AddDwellerItem")]
        public async Task<IActionResult> AddDwellerItem
            ([FromForm] IFormFile itemPhoto)
        {
            var dwellingIdClaim = User.FindFirst("HouseId");

            if (dwellingIdClaim is null)
                return BadRequest("Invalid dweller-details");

            var cmd = new AddDwellerItemCommand( 
                DwellingId: new Guid(dwellingIdClaim.Value),
                Name: Request.Form["name"],
                Desc: Request.Form["description"],
                ItemScope: Request.Form["itemScope"],
                ItemPhoto: itemPhoto);

            var handler = _commandHandler.GetHandler<AddDwellerItemCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("RemoveDwellerItem")]
        public async Task<IActionResult> RemoveDwellerItem
            (RemoveDwellerItemRequest request)
        {
            var cmd = new RemoveDwellerItemCommand(
                ItemId: request.ItemId);

            var handler = _commandHandler.GetHandler<RemoveDwellerItemCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("GetDwellerItem")]
        public async Task<IActionResult> GetDwellerItem([FromQuery] GetDwellerItemRequest request)
        {
            var query = new GetDwellerItemQuery(
                ItemId: request.ItemId);

            var handler = _queryHandlerFactory.GetHandler
                <GetDwellerItemQuery, GetDwellerItemResult>();

            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }


        [HttpGet("GetAllDwellerItems")]
        public async Task<IActionResult> GetAllDwellerItems()
         {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var query = new GetAllDwellerItemsQuery(
                DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandlerFactory.GetHandler
                <GetAllDwellerItemsQuery, GetAllDwellerItemsResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }
    }
}
