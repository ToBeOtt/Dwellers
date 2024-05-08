using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Offerings.Domain.DwellerItems
{
    public class BorrowedItem
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }
        public Guid DwellerItemId { get; set; }
        public DwellerItem DwellerItem { get; set; }    


        public string? Note { get; set; }

        public bool IsArchived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsReturned { get; private set; }

        public BorrowedItem() { }
        public BorrowedItem(Dwelling dwelling, DwellerItem dwellerItem)
        {
            Dwelling = dwelling;
            DwellerItem = dwellerItem;

            IsArchived = false;
            IsCreated = DateTime.UtcNow;
        }
    }
}
