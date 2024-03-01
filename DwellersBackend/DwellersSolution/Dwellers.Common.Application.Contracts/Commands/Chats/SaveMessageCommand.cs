namespace Dwellers.Common.Application.Contracts.Commands.Chats
{
    public record SaveMessageCommand(
        string MessageText,
        string DwellerId,
        Guid ConversationId);
}
