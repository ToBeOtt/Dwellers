using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Contracts.Queries.Chats;
using Dwellers.Common.Application.Contracts.Requests.Chats;
using Dwellers.Common.Application.Contracts.Results.Chats;
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
    [Route("chat")]
    public class ChatController(
      ICommandHandlerFactory commandHandler, IQueryHandlerFactory queryHandler) : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler = commandHandler;
        private readonly IQueryHandlerFactory _queryHandler = queryHandler;

        public class MessageDto
        {
            public Guid ConversationId { get; set; }
            public string Message { get; set; }
        }

        [HttpPost("SaveMessage")]
        public async Task<IActionResult> SaveMessage(SaveMessageRequest request)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
                throw new InvalidCredentialException();

            var cmd = new SaveMessageCommand(
                MessageText: request.Message,
                DwellerId: userIdClaim.Value,
                ConversationId: request.ConversationId);

            var handler = _commandHandler.GetHandler<SaveMessageCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        [HttpPost("GetDwellingConversation")]
        public async Task<IActionResult> GetDwellingConversation(GetDwellingConversationRequest? request)
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();
            Guid? conversationId = request?.ConversationId;

            // ConversationId may optionally be null, depending on defaulting dwelling-conversation or if a specific conversation is requested. 
            var query = new GetDwellingConversationQuery(
              DwellingId: new Guid(dwellingIdClaim.Value),
              ConversationId: conversationId);

            var handler = _queryHandler.GetHandler<GetDwellingConversationQuery, GetDwellingConversationResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetAllDwellingConversations")]
        public async Task<IActionResult> GetAllDwellingConversations()
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var query = new GetAllDwellingConversationsQuery(
               DwellingId: new Guid(dwellingIdClaim.Value));

            var handler = _queryHandler.GetHandler<GetAllDwellingConversationsQuery, GetAllDwellingConversationsResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        
        [HttpPost("AddDwellingConversation")]
        public async Task<IActionResult> AddDwellingConversation(AddDwellingConversationRequest request)
        {
            var dwellingIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            var cmd = new AddDwellingConversationCommand(
               InvitedConversationMembers: request.InvitedConversationMembers,
               InviterId: new Guid(dwellingIdClaim.Value));

            var handler = _commandHandler.GetHandler<AddDwellingConversationCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result);
               
            }
            return Ok();
        }
    }
}
