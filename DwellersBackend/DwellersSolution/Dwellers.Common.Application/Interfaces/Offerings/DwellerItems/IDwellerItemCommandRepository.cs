using Dwellers.Offerings.Domain.DwellerItems;

namespace Dwellers.Common.Application.Interfaces.Offerings.DwellerItems
{
    public interface IDwellerItemCommandRepository
    {
        Task<bool> AddDwellerItem(DwellerItem item);
        Task<bool> RegisterItemStatus(BorrowedItem borrowedItem);
        Task<bool> RemoveDwellerItem(DwellerItem item);
    }
}
