using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.Offerings.Domain.DwellerItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerItems
{
    public class DwellerItemCommandRepository : IDwellerItemCommandRepository
    {
        private readonly ILogger<DwellerItemCommandRepository> _logger;
        private readonly DwellerDbContext _context;

        public DwellerItemCommandRepository(
            ILogger<DwellerItemCommandRepository> logger,
            DwellerDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public async Task<bool> AddDwellerItem(DwellerItem item)
        {
            try
            {
                await _context.DwellerItems.AddAsync(item);
                int result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while adding DwellerItem: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RemoveDwellerItem(DwellerItem dwellerItem)
        {
            try
            {
                _context.DwellerItems.Remove(dwellerItem);
                int result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while removing DwellerItem: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RegisterItemStatus(BorrowedItem borrowedItem)
        {
            try
            {
                await _context.BorrowedItems.AddAsync(borrowedItem);
                int result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while registering item-status: " + ex.Message);
                return false;
            }

        }
    }
}
