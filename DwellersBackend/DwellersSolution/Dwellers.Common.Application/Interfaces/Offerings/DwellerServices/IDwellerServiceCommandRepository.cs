using Dwellers.Offerings.Domain.DwellerServices;

namespace Dwellers.Common.Application.Interfaces.Offerings.DwellerServices
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(DwellerService service);
        Task<bool> RegisterProvidedService(ProvidedService service);
        Task<bool> RemoveDwellerService(DwellerService service);
    }
}
