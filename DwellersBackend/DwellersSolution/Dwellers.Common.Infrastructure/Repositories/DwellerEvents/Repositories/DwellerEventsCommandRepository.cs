using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.DwellerEvents.Repositories
{
    public class DwellerEventsCommandRepository(
        DwellerDbContext context,
        ILogger<DwellerEventsCommandRepository> logger) : IDwellerEventsCommandRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<DwellerEventsCommandRepository> _logger = logger;

        public async Task<bool> AddEventAsync(DwellerEvent dwellerEvent)
        {
            try
            {
                await _context.DwellerEvents.AddAsync(dwellerEvent);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AddEventAsync: {exMessage}", ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEventAsync(DwellerEvent dwellerEvent)
        {
            try
            {
                _context.DwellerEvents.Remove(dwellerEvent);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing DeleteEventAsync: {exMessage}", ex.Message);
                return false;
            }
        }
    }
}
