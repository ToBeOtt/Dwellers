using Dwellers.DwellerCore.Domain.Entities.Dwellers;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers
{
    public interface IDwellerCommandRepository
    {
        Task<bool> AddDwellerAsync(Dweller dweller);
        Task<bool> DeleteDwellerAsync(Dweller dweller);
    }
}
