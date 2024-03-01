using Dwellers.Common.Application.Interfaces.Offerings.DwellerItems;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.Offerings.Domain.DwellerItems;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Infrastructure.Repositories.Offerings.Repositories.DwellerItems
{
    public class DwellerItemQueryRepository : IDwellerItemQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerItemQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerItem>> GetAllDwellerItems(Guid dwellingId)
        {
            return await _context.DwellerItems
                                .Include(di => di.BorrowedItems)
                                .Where(di => di.BorrowedItems.Any
                                (bi => bi.DwellingId == dwellingId &&
                                    bi.IsArchived == false))
                                .ToListAsync();
        }

        public async Task<DwellerItem> GetDwellerItem(Guid ItemId)
        {
            return await _context.DwellerItems
                            .Include(di => di.BorrowedItems)
                            .Where(di => di.Id == ItemId)
                            .SingleOrDefaultAsync();
        }
    }
}
