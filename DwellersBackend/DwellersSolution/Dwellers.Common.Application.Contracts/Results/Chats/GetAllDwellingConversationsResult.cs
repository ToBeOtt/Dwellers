namespace Dwellers.Common.Application.Contracts.Results.Chats
{
    public class ConversationInfo(Guid id, string name)
    {
        public Guid Id { get; private set; } = id;
        public string Name { get; private set; } = name;
    }
    public record GetAllDwellingConversationsResult (
        ICollection<ConversationInfo> Conversations
        );
}
