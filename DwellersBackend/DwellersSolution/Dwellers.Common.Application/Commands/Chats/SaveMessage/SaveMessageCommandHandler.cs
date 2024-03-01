using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Chats.SaveMessage
{
    public class SaveMessageCommandHandler(
        ILogger<SaveMessageCommandHandler> logger,
        IChatQueryRepository chatQueryRepository,
        IChatCommandRepository chatCommandRepository,
        IDwellerQueryRepository dwellerQuery) : ICommandHandler<SaveMessageCommand, DwellerUnit>
    {
        private readonly ILogger<SaveMessageCommandHandler> _logger = logger;
        private readonly IChatQueryRepository _chatQueryRepository = chatQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository = chatCommandRepository;
        private readonly IDwellerQueryRepository _dwellerQuery = dwellerQuery;

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (SaveMessageCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var conversation = await _chatQueryRepository.GetConversation(cmd.ConversationId);

            var dweller = await _dwellerQuery.GetDwellerByIdAsync(cmd.DwellerId);
            if (conversation is null || dweller is null)
                return await response.ErrorResponse("Something went wrong.");

            // Create new message
            DwellerMessage message = new(cmd.MessageText, dweller, conversation);

            if (!await _chatCommandRepository.AddMessageAsync(message))
                return await response.ErrorResponse("Message could not be sent.");

            return await response.SuccessResponse();
        }
    }
}
