using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedKernel.Domain;

namespace Dwellers.Chat.Domain.Entities
{
    public sealed class DwellerMessage : BaseEntity
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; }

        public string DwellerId { get; set; }
        public Dweller Dweller { get; set; }

        public Guid ConversationId { get; set; }
        public DwellerConversation Conversation { get; set; }

        public bool Archived { get; private set; }
        public DateTime Timestamp { get; private set; }
        public DateTimeOffset? IsModified { get; private set; }

        public DwellerMessage() { }
        public DwellerMessage(string message, Dweller dweller, DwellerConversation conversation)
        {
            Id = Guid.NewGuid();
            MessageText = message;
            Timestamp = DateTime.UtcNow;
            Dweller = dweller;
            Conversation = conversation;
        }


    }
}

