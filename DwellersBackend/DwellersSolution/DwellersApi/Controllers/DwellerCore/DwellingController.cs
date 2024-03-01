using Dwellers.Common.Application.Contracts.Commands.Dwellers;
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


        
    }
}