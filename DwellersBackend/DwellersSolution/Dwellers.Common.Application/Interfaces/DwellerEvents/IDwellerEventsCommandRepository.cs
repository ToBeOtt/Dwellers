using Dwellers.DwellersEvents.Domain.Entites;

namespace Dwellers.Common.Application.Interfaces.DwellerEvents
{
    public interface IDwellerEventsCommandRepository
    {
        Task<bool> AddEventAsync(DwellerEvent dwellerEvent);
        Task<bool> DeleteEventAsync(DwellerEvent dwellerEvent);  
    }
}
