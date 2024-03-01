using Dwellers.Chat.Domain.Entities;

namespace Dwellers.Common.Application.Interfaces.Chats
{
    public interface IChatCommandRepository
    {
        Task<bool> AddMessageAsync(DwellerMessage message);
        Task<bool> AddConversationAsync(DwellerConversation conversation);
        Task<bool> AddMembersInConversationAsync(List<MemberInConversation> listOfMembers);
    }
}
