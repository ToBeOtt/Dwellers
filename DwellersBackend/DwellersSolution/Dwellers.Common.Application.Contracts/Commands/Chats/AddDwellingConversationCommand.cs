namespace Dwellers.Common.Application.Contracts.Commands.Chats
{
    public record AddDwellingConversationCommand(
        List<Guid> InvitedConversationMembers,
        Guid InviterId
        );
}
