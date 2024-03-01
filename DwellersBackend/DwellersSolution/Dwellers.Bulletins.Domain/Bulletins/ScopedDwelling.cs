using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class ScopedDwelling
    {
        public Guid Id { get; set; }

        public Guid BulletinId { get; set; }
        public Bulletin Bulletin { get; set; }


        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }

        public ScopedDwelling() { }
        internal ScopedDwelling(Bulletin bulletin, Dwelling dwelling)
        {
            Id = Guid.NewGuid();
            Bulletin = bulletin;
            Dwelling = dwelling;
        }
    }
}
