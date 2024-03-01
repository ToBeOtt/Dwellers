using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Dwellers.GetDwellerDetails
{
    public class GetDwellerDetailsQueryHandler :
        IQueryHandler<GetDwellerDetailsQuery, GetDwellerDetailsResult>
    {
        private readonly ILogger<GetDwellerDetailsQueryHandler> _logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public GetDwellerDetailsQueryHandler
            (ILogger<GetDwellerDetailsQueryHandler> logger,
            IDwellerQueryRepository dwellerQueryRepository,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _dwellerQueryRepository = dwellerQueryRepository;
            _dwellingQueryRepository = dwellingQueryRepository;
        }
        public async Task<DwellerResponse<GetDwellerDetailsResult>> Handle
            (GetDwellerDetailsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellerDetailsResult> response = new();

            var dweller = await _dwellerQueryRepository.GetDwellerByIdAsync(query.DwellerId);
            if (dweller is null)
                return await response.ErrorResponse("Dweller details could not be fetched.");

            var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(query.DwellingId);
            if (dwelling is null)
                return await response.ErrorResponse
                    ("Dwelling could not be fetched.");

            return await response.SuccessResponse(
                new(DwellerId: dweller.Id,
                     DwellingId: dwelling.Id));
        }
    }
}
