using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Chats.EstablishConversation
{
    public class EstablishConversationCommandHandler(
        ILogger<EstablishConversationCommandHandler> logger,
        IChatQueryRepository chatQueryRepository,
        IChatCommandRepository chatCommandRepository,
        IDwellingQueryRepository dwellingQueryRepository) : ICommandHandler<EstablishConversationCommand, DwellerUnit>
    {
        private readonly ILogger<EstablishConversationCommandHandler> _logger = logger;
        private readonly IChatQueryRepository _chatQueryRepository = chatQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository = chatCommandRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository = dwellingQueryRepository;

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (EstablishConversationCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();
            
            DwellerConversation conversation = new($"{cmd.DwellingName} chat");

            var listOfDwellings = await GetDwellingsFromGuids(cmd.ListOfDwellingIds);
            var listOfConversationMembers = await GetDwellingForConversation(listOfDwellings, conversation);

            //persist conversation member
            if (!await _chatCommandRepository.AddConversationAsync(conversation))
                return await response.ErrorResponse
                        ("Conversation could not be created.");

            if (!await _chatCommandRepository.AddMembersInConversationAsync(listOfConversationMembers))
                return await response.ErrorResponse
                        ("Members could not be added to conversation.");

            return await response.SuccessResponse();
        }

        private async Task<List<Dwelling>> GetDwellingsFromGuids(List<Guid> listOfDwellingIds)
        {
            try
            {
                return await _dwellingQueryRepository.GetAllDwellingsByListOfIdsAsync(listOfDwellingIds);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error executing GetDwellingsFromGuids: {ex.Message}", ex.Message);
                return [];
            }
        }
        private async Task<List<MemberInConversation>> GetDwellingForConversation(List<Dwelling> listOfDwellings, DwellerConversation conversation)
        {
            try
            {
                return await conversation.AttachMemberToConversation(listOfDwellings, conversation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AttachMemberToConversation: {ex.Message}", ex.Message);
                return [];
            }
        }
    }
}
