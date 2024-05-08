using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Results.Chats;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Common.Application.Interfaces.Chats
{
    public interface IChatQueryRepository
    {
        Task<DwellerConversation> GetConversation(Guid conversationId);
        Task<DwellerConversation> GetDwellerConversationById(Guid conversationId);   
        Task<DwellerConversation> GetDwellerConversationByDwellingId(Guid dwellingId);
        Task<ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId);
        Task<ICollection<ConversationInfo>> GetAllDwellingConversations(Guid dwellingId);
        Task<bool> ConversationAlreadyExists(List<Dwelling> dwellingsInConversation);

        
    }
}
