using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Graph.Models;
using SharedKernel.Domain;

namespace Dwellers.Chat.Domain.Entities
{
    public class DwellerConversation : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsArchived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public ICollection<MemberInConversation> MemberInConversation { get; set; }

        public DwellerConversation() { }

        public DwellerConversation(string nameOfConversation)
        {
            Id = Guid.NewGuid();
            Name = nameOfConversation;

            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }
       
        public async Task<List<MemberInConversation>> AttachMemberToConversation(List<Dwelling> listOfDwellings, DwellerConversation conversation)
        {
            ArgumentNullException.ThrowIfNull(listOfDwellings);
            var memberList = new List<MemberInConversation>();

            foreach (Dwelling dwelling in listOfDwellings)
            {
                var member = new MemberInConversation(dwelling, conversation);
                memberList.Add(member);
            }
            return memberList;
        }

        public static MemberInConversation AddNewConversationMembers(Dwelling dwelling, DwellerConversation conversation)
        {
            return new MemberInConversation(dwelling, conversation);
        }
    }
}

