using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellings
{
    public class DwellingCommandRepository : IDwellingCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<DwellingCommandRepository> _logger;

        public DwellingCommandRepository(DwellerDbContext context, 
            ILogger<DwellingCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddDwellingAsync(Dwelling Dwelling)
        {
            try
            {
                await _context.Dwellings.AddAsync(Dwelling);
                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Dwelling could not be saved to database. {ex.Message}", ex.Message);
                return false;
            }  
        }
        public async Task<bool> AddDwellerInhabitantAsync(DwellingInhabitant DwellerInhabitant)
        {
            try
            {
                await _context.DwellingInhabitants.AddAsync(DwellerInhabitant);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dweller could not be added and saved to database. {ex.Message}", ex.Message);
                return false;
            }    
        }

        public async Task<bool> DeleteDwellingAsync(Dwelling Dwelling)
        {
            try
            {
                _context.Dwellings.Remove(Dwelling);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dwelling could not be deleted from database. {ex.Message}", ex.Message);
                return false;
            }
        }
    }
}
