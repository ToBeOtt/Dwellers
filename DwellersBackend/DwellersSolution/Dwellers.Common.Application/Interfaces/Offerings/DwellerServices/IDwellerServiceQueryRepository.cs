using Dwellers.Offerings.Domain.DwellerServices;

namespace Dwellers.Common.Application.Interfaces.Offerings.DwellerServices
{
    public interface IDwellerServiceQueryRepository
    {
        Task<DwellerService> GetDwellerService(Guid ServiceId);
        Task<ICollection<DwellerService>> GetAllDwellerServices(Guid houseId);
    }
}
