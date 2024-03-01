using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using SharedKernel.Domain;

namespace Dwellers.DwellerCore.Domain.Entities
{
    public class DwellingInhabitant : ValueObject
    {
        public Guid Id { get; set; }
        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }

        public string DwellerId { get; set; }
        public Dweller Dweller{ get; set; }

        public DwellingInhabitant() { }
        internal DwellingInhabitant(Dwelling dwelling, Dweller dweller)
        {
            Id = Guid.NewGuid();
            Dwelling = dwelling;
            Dweller = dweller;
        }
        public static class DwellingInhabitantFactory
        {
            public static async Task<DwellingInhabitant> Create(Dwelling Dwelling, Dweller dweller)
            {
                return new DwellingInhabitant(Dwelling, dweller);
            }
        }
    }
}
