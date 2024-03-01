using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings
{
    public interface IDwellingCommandRepository
    {
        Task<bool> AddDwellingAsync(Dwelling Dwelling);
        Task<bool> AddDwellerInhabitantAsync(DwellingInhabitant DwellerInhabitant);
        Task<bool> DeleteDwellingAsync(Dwelling Dwelling);
    }
}
