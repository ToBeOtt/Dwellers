using Dwellers.Common.Application.Interfaces.Offerings.DwellerServices;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.Offerings.Domain.DwellerServices;

namespace Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerServices
{
    public class DwellerServiceQueryRepository : IDwellerServiceQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerServiceQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerService>> GetAllDwellerServices(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).ToListAsync();
        }

        public async Task<DwellerService> GetDwellerService(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).SingleOrDefaultAsync();
        }
    }
}
