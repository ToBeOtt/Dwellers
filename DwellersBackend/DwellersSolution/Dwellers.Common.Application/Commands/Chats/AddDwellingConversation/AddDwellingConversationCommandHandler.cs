using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using System.Text;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Chats.AddDwellingConversationCommandHandler
{
    public class AddDwellingConversationCommandHandler(
        ILogger<AddDwellingConversationCommandHandler> logger,
        IChatQueryRepository chatQueryRepository,
        IChatCommandRepository chatCommandRepository,
        IDwellingQueryRepository dwellingQueryRepository) : ICommandHandler<AddDwellingConversationCommand, DwellerUnit>
    {
        private readonly ILogger<AddDwellingConversationCommandHandler> _logger = logger;
        private readonly IChatQueryRepository _chatQueryRepository = chatQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository = chatCommandRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository = dwellingQueryRepository;

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddDwellingConversationCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var inviterDwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(cmd.InviterId);
            var fetchedDwellingsForConversation = await _dwellingQueryRepository.GetAllDwellingsByListOfIdsAsync(cmd.InvitedConversationMembers);

            // check that all members are friends with inviter
            foreach (var dwelling in fetchedDwellingsForConversation)
            {
                var checkFriendship = inviterDwelling.DwellingFriends.Contains(dwelling.Id);
                if (!checkFriendship)
                {
                    return await response.ErrorResponse("One or several dwellings were not connected.");
                }                  
            }
            fetchedDwellingsForConversation.Add(inviterDwelling);

            // Default name
            string combinedNames = string.Join(", ", fetchedDwellingsForConversation.Select(dwelling => dwelling.Name));
            DwellerConversation conversation = new();
            conversation.Name = combinedNames;

            var listOfConversationMembers = await GetDwellingForConversation(fetchedDwellingsForConversation, conversation);

            // Check that an exact replica of conversation already exists
            if(await _chatQueryRepository.ConversationAlreadyExists(fetchedDwellingsForConversation))
                return await response.ErrorResponse
                        ("This conversation already exists", true);

            if (!await _chatCommandRepository.AddConversationAsync(conversation))
                return await response.ErrorResponse
                        ("Conversation could not be created.");

            if (!await _chatCommandRepository.AddMembersInConversationAsync(listOfConversationMembers))
                return await response.ErrorResponse
                        ("Members could not be added to conversation.");

            return await response.SuccessResponse();
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
