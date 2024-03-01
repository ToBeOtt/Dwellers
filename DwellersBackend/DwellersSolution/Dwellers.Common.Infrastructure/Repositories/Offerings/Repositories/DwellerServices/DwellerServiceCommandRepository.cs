using Dwellers.Common.Application.Interfaces.Offerings.DwellerServices;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerServices
{
    public class DwellerServiceCommandRepository : IDwellerServiceCommandRepository
    {
        private readonly ILogger<DwellerServiceCommandRepository> _logger;
        private readonly DwellerDbContext _context;

        public DwellerServiceCommandRepository(
            ILogger<DwellerServiceCommandRepository> logger,
            DwellerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> AddDwellerService(DwellerService service)
        {
            await _context.DwellerServices.AddAsync(service);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public Task<bool> RegisterProvidedService(ProvidedService service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDwellerService(DwellerService service)
        {
            throw new NotImplementedException();
        }
    }
}
