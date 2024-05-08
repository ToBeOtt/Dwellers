namespace Dwellers.Common.Application.Contracts.Requests.Chats
{
    public record AddDwellingConversationRequest(
        List<Guid> InvitedConversationMembers);
}
