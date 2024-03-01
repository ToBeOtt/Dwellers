using Dwellers.Offerings.Domain.DwellerItems;

namespace Dwellers.Common.Application.Interfaces.Offerings.DwellerItems
{
    public interface IDwellerItemQueryRepository
    {
        Task<DwellerItem> GetDwellerItem(Guid ItemId);
        Task<ICollection<DwellerItem>> GetAllDwellerItems(Guid houseId);
    }
}
