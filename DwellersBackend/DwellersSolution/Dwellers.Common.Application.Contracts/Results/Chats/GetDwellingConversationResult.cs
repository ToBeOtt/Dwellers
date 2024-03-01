using Dwellers.Common.Application.Contracts.Results.Chats.DTOs;

namespace Dwellers.Common.Application.Contracts.Results.Chats
{
    public record GetDwellingConversationResult(
        Guid ConversationId,
        List<DwellerMessageDto> MessageList);
}
