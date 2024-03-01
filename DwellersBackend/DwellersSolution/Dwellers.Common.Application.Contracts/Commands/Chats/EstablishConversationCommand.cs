namespace Dwellers.Common.Application.Contracts.Commands.Chats
{
    public record EstablishConversationCommand(
        List<Guid> ListOfDwellingIds,
        string DwellingName
        );
}
