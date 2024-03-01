using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using SharedKernel.Domain;

namespace Dwellers.Chat.Domain.Entities
{
    public sealed class MemberInConversation : ValueObject
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }  
        public Guid ConversationId { get; set; }
        public DwellerConversation Conversation { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public MemberInConversation() { }
        //internal MemberInConversation(Dwelling dwelling, DwellerConversation conversation)
        //{
        //    Id = Guid.NewGuid();
        //    Dwelling = dwelling;
        //    Conversation = conversation;
        //}
        public MemberInConversation(Dwelling dwelling, DwellerConversation conversation)
        {
            Id = Guid.NewGuid();
            Dwelling = dwelling;
            Conversation = conversation;
        }
    }
}
