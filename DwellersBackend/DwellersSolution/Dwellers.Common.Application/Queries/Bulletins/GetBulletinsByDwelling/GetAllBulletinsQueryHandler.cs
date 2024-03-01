using Dwellers.Common.Application.Contracts.Queries.Bulletins;
using Dwellers.Common.Application.Contracts.Results.Bulletins;
using Dwellers.Common.Application.Contracts.Results.Bulletins.DTOs;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Bulletins.GetBulletinsByDwelling
{
    public class GetAllBulletinsQueryHandler(ILogger<GetAllBulletinsQueryHandler> logger,
        IBulletinQueryRepository bulletinQueryRepository) :
        IQueryHandler<GetAllBulletinsQuery, GetAllBulletinsResult>
    {
        private readonly ILogger<GetAllBulletinsQueryHandler> _logger = logger;
        private readonly IBulletinQueryRepository _bulletinQueryRepository = bulletinQueryRepository;

        public async Task<DwellerResponse<GetAllBulletinsResult>> Handle
            (GetAllBulletinsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetAllBulletinsResult> response = new();

            var listOfBulletins = await _bulletinQueryRepository.GetAllBulletinsForDwelling(query.DwellingId);

            var listOfBulletinsDto = new List<BulletinListDto>();
            foreach (var bulletin in listOfBulletins)
            {
                var dashboardBulletin = new BulletinListDto(bulletin.Title,
                    bulletin.Dweller.Alias,
                    bulletin.Text,
                    bulletin.Scope.Visibility.ToString(),
                    bulletin.IsCreated.ToShortDateString(),
                    bulletin.IsModified.ToShortDateString());
                listOfBulletinsDto.Add(dashboardBulletin);
            }


            return await response.SuccessResponse(
                new(ListOfAllBulletins: listOfBulletinsDto));
        }
    }
}
