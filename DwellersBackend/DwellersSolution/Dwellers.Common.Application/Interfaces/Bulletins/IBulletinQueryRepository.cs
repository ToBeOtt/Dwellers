using Dwellers.Bulletins.Domain.Bulletins;

namespace Dwellers.Common.Application.Interfaces.Bulletins
{
    public interface IBulletinQueryRepository
    {
        Task<Bulletin> GetByIdAsync(Guid id);
        Task<List<Bulletin>> GetDashboardBulletinsAsync(Guid id);
        Task<List<Bulletin>> GetAllBulletinsForDwelling(Guid id);
        
    }
}
