using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Offerings.Domain.DwellerServices
{
    public class ProvidedService
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }
        public Guid ServiceId { get; set; }
        public DwellerService DwellerService { get; set; }
        
        public bool IsProvider { get; set; }
        public string? Note { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }
        public bool? ServiceReturned { get; set; }

        public ProvidedService() { }

        public ProvidedService(Dwelling dwelling, DwellerService dwellerService, bool isProvider)
        {
            Dwelling = dwelling;
            DwellerService = dwellerService;
            IsProvider = isProvider;
        }
    }
}
