using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellings
{
    public class DwellingQueryRepository : IDwellingQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellingQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<List<string>> GetAllDwellingNames()
        {
            return await _context.Dwellings.Select(h => h.Name).ToListAsync();
        }

        public async Task<Dwelling> GetDwellingByIdAsync(Guid id)
        {
            return await _context.Dwellings.Where(d => d.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Dwelling> GetDwellingByDwellingInhabitantAsync(string dwellerId)
        {
            var dwelling = await _context.Dwellings
                            .Include(d => d.DwellingInhabitant)
                                .ThenInclude(di => di.Dweller)
                            .Where(d => d.DwellingInhabitant.DwellerId == dwellerId)
                            .SingleOrDefaultAsync();
            return dwelling;
        }

        public async Task<List<Dwelling>> GetAllDwellingsByListOfIdsAsync(List<Guid> listOfDwellings)
        {
            var dwellings = await _context.Dwellings
                            .Where(d => listOfDwellings
                            .Contains(d.Id))
                            .ToListAsync();

            return dwellings;
        }
    }
}