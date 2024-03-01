using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.Chats.Repositories
{
    public class ChatCommandRepository : IChatCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            DwellerDbContext context,
            ILogger<ChatCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddMessageAsync(DwellerMessage message)
        {
            try
            {
                await _context.DwellerMessages.AddAsync(message);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AddMessageAsync: {ex.Message}", ex.Message);
                return false;
            }
        }

        public async Task<bool> AddConversationAsync(DwellerConversation conversation)
        {
            try
            {
                await _context.DwellerConversations.AddAsync(conversation);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AddConversationAsync: {ex.Message}", ex.Message);
                return false;
            } 
        }

        public async Task<bool> AddMembersInConversationAsync(List<MemberInConversation> listOfMembers)
        {
            try
            {
                foreach(MemberInConversation member in listOfMembers)
                {
                    await _context.MemberInConversations.AddAsync(member);
                }
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AddMembersInConversationAsync: {ex.Message}", ex.Message);
                return false;
            }
            
        }
    }
}