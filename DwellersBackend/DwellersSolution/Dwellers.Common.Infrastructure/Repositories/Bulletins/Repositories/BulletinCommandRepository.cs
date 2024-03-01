using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.Bulletins.Repositories
{
    public class BulletinCommandRepository(DwellerDbContext context, 
        ILogger<BulletinCommandRepository> logger) : IBulletinCommandRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<BulletinCommandRepository> _logger = logger;

        public async Task<bool> AddBulletinAsync(Bulletin bulletin)
        {
            try
            {
                _ = _context.Bulletins.AddAsync(bulletin);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing AddBulletinAsync: {exMessage}", ex.Message);
                return false;
            }
        }   
        public async Task<bool> DeleteBulletinAsync(Bulletin bulletin)
        {
            try
            {
                _context.Bulletins.Remove(bulletin);
                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error executing DeleteBulletinAsync: {exMessage}", ex.Message);
                return false;
            }
               
        }
    }
}
