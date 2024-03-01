using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellers
{
    public class DwellerQueryRepository(DwellerDbContext context, ILogger<DwellerQueryRepository> logger) : IDwellerQueryRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<DwellerQueryRepository> _logger = logger;

        public async Task<List<string>> GetAllDwellersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Dweller?> GetDwellerByIdAsync(string id)
        {
            try
            {
                return await _context.Dwellers.Where(u => u.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing GetDwellerByEmail: {ErrorMessage}", ex.Message);
                return null;
            }
            
        }

        public async Task<Dweller?> GetDwellerByEmailAsync(string email)
        {
            try
            {
                return await _context.Dwellers.Where(u => u.Email == email).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing GetDwellerByEmail: {ErrorMessage}", ex.Message);
                return null;
            }
        }
    }
}
