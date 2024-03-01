using Dwellers.DwellerCore.Domain.Entities.Dwellers;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers
{
    public interface IDwellerQueryRepository
    {
        Task<List<string>> GetAllDwellersAsync();
        Task<Dweller?> GetDwellerByIdAsync(string id);
        Task<Dweller?> GetDwellerByEmailAsync(string email);
    }
}
