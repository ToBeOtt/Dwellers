using Dwellers.Common.Application.Contracts.Queries.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;


namespace Dwellers.Common.Application.Queries.Dwellings.GetDwellingByEmail
{
    public class GetDwellingByEmailQueryHandler(ILogger<GetDwellingByEmailQueryHandler> logger,
        IDwellerQueryRepository dwellerQueryRepository,
        IDwellingQueryRepository dwellingQueryRepository) :
        IQueryHandler<GetDwellingByEmailQuery, GetDwellingByEmailResult>
    {
        private readonly ILogger<GetDwellingByEmailQueryHandler> _logger = logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository = dwellerQueryRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository = dwellingQueryRepository;

        public async Task<DwellerResponse<GetDwellingByEmailResult>> Handle
            (GetDwellingByEmailQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellingByEmailResult> response = new();

            var dweller = await _dwellerQueryRepository.GetDwellerByEmailAsync(query.Email);

            var dwelling = await _dwellingQueryRepository.GetDwellingByDwellingInhabitantAsync(dweller.Id);

            return await response.SuccessResponse(
                new GetDwellingByEmailResult(
                    DwellingId: dwelling.Id));
        }
    }
}
