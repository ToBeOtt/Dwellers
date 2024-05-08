using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellersEvents.Domain.Entites.ValueObjects;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellersEvents.Domain.Entites
{
    public sealed class DwellerEvent : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; set; }
        public DwellerScope? EventScope { get; private set; }
        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public Dweller Dweller { get; set; }
        public Dwelling Dwelling { get; set; }

        public DwellerEvent() { }
        private DwellerEvent(string title, string desc, Dwelling dwelling, Dweller dweller, string visibility)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = desc;
            Dwelling = dwelling;
            Dweller = dweller;
            EventScope = DwellerScope.VisibilityFactory.CreateNewVisibilityScope(visibility);

            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }

        public static class DwellerEventFactory
        {
            public static DwellerEvent CreateNewDwellerEvent(
                 string title, 
                 string desc, 
                 Dwelling dwelling, 
                 Dweller dweller,
                 string visibility)
            {
                return new DwellerEvent(title, desc,
                    dwelling, dweller, visibility);
            }
        }

        public static string ConvertEnumToString(int value)
        {
            var visibilityScope = DwellerScope.FromDbValue(value);
            return visibilityScope.ToString();
        }
    }
}
