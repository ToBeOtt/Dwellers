namespace Dwellers.Common.Application.Contracts.Queries.Chats
{
    public record GetDwellingConversationQuery(
        Guid DwellingId,
        Guid? ConversationId); // This can intentionally be null
     
}
