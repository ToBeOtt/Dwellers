using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellers
{
    public class DwellerCommandRepository(DwellerDbContext context, ILogger<DwellerCommandRepository> logger) : IDwellerCommandRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<DwellerCommandRepository> _logger = logger;

        public async Task<bool> AddDwellerAsync(Dweller dweller)
        {
            try
            {
                await _context.Dwellers.AddAsync(dweller);
                return await _context.SaveChangesAsync() > 0;
    }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing GetDwellerByEmail: {ErrorMessage}", ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDwellerAsync(Dweller dweller)
        {
            try
            {
                _context.Dwellers.Remove(dweller);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing DeleteDwellerAsync: {ErrorMessage}", ex.Message);
                return false;
            }
        }
    }
}
