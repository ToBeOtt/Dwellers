using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Results.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.Repositories.Chats.Repositories
{
    public class ChatQueryRepository : IChatQueryRepository
    {
        private readonly DwellerDbContext _context;

        public ChatQueryRepository(
            DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<DwellerConversation> GetConversation(Guid conversationId)
        {
            return
                await _context.DwellerConversations
                .Where(c => c.Id == conversationId)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId)
        {
            return
                await _context.DwellerMessages
                .Include(dm => dm.Dweller)
                .Where(m => m.ConversationId == conversationId)
                .ToListAsync();
        }

        public async Task<DwellerConversation> GetDwellerConversationById(Guid conversationId)
        {
            return await _context.DwellerConversations
                .Where(x => x.Id == conversationId)
                .SingleOrDefaultAsync();
        }

        public async Task<DwellerConversation> GetDwellerConversationByDwellingId(Guid dwellingId)
        {
            return await _context.DwellerConversations
                .Include(x => x.MemberInConversation)
                .Where(conversation => conversation.MemberInConversation.Count == 1 &&
                                        conversation.MemberInConversation.Any(member => member.DwellingId == dwellingId))
                .SingleOrDefaultAsync();
        }
        public async Task<ICollection<ConversationInfo>> GetAllDwellingConversations(Guid dwellingId)
        {
            var conversations = await _context.DwellerConversations
                 .Where(y => y.MemberInConversation.Any(m => m.DwellingId == dwellingId))
                 .Select(conversation => new ConversationInfo
                 (
                     conversation.Id,
                     conversation.Name
                 ))
                 .ToListAsync();

            return conversations;
        }

        public async Task<bool> ConversationAlreadyExists(List<Dwelling> dwellingsInConversation)
        {
            var dwellingIds = dwellingsInConversation.Select(dwelling => dwelling.Id).ToList();

            // Check if a conversation with the exact same IDs exists
            return _context.DwellerConversations
                .Any(conversation => conversation.MemberInConversation.Count == dwellingIds.Count &&
                                     conversation.MemberInConversation.All(member => dwellingIds.Contains(member.DwellingId)));
        }
        
    }
}