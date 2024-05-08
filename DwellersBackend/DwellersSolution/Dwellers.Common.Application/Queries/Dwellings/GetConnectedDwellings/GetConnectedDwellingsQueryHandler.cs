using Dwellers.Common.Application.Contracts.Queries.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Dwellings.GetConnectedDwellings
{
    public class GetConnectedDwellingsQueryHandler(ILogger<GetConnectedDwellingsQueryHandler> logger,
        IDwellingQueryRepository dwellingQueryRepository) :
        IQueryHandler<GetConnectedDwellingsQuery, GetConnectedDwellingsResult>
    {
        private readonly ILogger<GetConnectedDwellingsQueryHandler> _logger = logger;
        private readonly IDwellingQueryRepository _dwellingQueryRepository = dwellingQueryRepository;

        public async Task<DwellerResponse<GetConnectedDwellingsResult>> Handle
            (GetConnectedDwellingsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetConnectedDwellingsResult> response = new();

            var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(query.DwellingId);

            var connectedDwellings = await _dwellingQueryRepository.GetConnectedDwellingsById(dwelling.DwellingFriends);

            var result = connectedDwellings
                        .ToDictionary(dwelling => dwelling.Id, dwelling => dwelling.Name);

            return await response.SuccessResponse(new GetConnectedDwellingsResult(ConnectedDwellings: result));
        }
    }
}
