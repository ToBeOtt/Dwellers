using Dwellers.Bulletins.Domain.Bulletins;

namespace Dwellers.Common.Application.Interfaces.Bulletins
{
    public interface IBulletinCommandRepository
    {
        Task<bool> AddBulletinAsync(Bulletin bulletin); 
        Task<bool> DeleteBulletinAsync(Bulletin bulletin);
    }
}
