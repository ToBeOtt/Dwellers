using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Infrastructure.Context;
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

        public async Task<DwellerConversation> GetDwellerConversation(Guid dwellingId)
        {
               return await _context.DwellerConversations
                    .Include(x => x.MemberInConversation)
                    .Where(y => y.MemberInConversation.Any(m => m.DwellingId == dwellingId))
                    .SingleOrDefaultAsync();
        }
    }
}