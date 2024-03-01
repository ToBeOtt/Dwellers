using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.Repositories.DwellerEvents.Repositories
{
    internal class DwellerEventsQueryRepository : IDwellerEventsQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerEventsQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerEvent>> GetAllEvents(Guid dwellingId)
        {
            return await _context.DwellerEvents
                    .Include(e => e.Dwelling)
                    .Include(e => e.Dweller)
                    .Where(e => e.Dwelling.Id == dwellingId)
                    .OrderBy(e => e.IsCreated)
                    .ToListAsync();
        }

        public async Task<ICollection<DwellerEvent>> GetUpcomingEvents(Guid dwellingId)
        {

            return await _context.DwellerEvents
                    .Include(e => e.Dwelling)
                    .Include(e => e.Dweller)
                    .ToListAsync();

            //return await _context.DwellerEvents
            //   .Include(e => e.Dweller)
            //   .Where(e => e.Dwelling != null && e.Dwelling.Id == dwellingId)
            //   .Where(e => !e.IsArchived)
            //   .OrderByDescending(e => e.EventDate)
            //   .Take(10)
            //   .ToListAsync();
        }

        public async Task<DwellerEvent> GetEvent(Guid eventId)
        {
            return await _context.DwellerEvents
                .Where(e => e.Id == eventId)
                .Include(e => e.Dwelling)
                .Include(e => e.Dweller)
                .Include(e => e.EventScope)
                .SingleOrDefaultAsync();
        }
    }
}
