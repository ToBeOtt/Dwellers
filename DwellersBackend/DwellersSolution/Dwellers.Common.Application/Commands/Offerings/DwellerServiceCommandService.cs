using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Application.Interfaces.Offerings.DwellerServices;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerServices
{
    public class DwellerServiceCommandService
    {
        private readonly ILogger<DwellerServiceCommandService> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;
        private readonly IDwellerServiceCommandRepository _dwellerServiceCommandRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public DwellerServiceCommandService(
            ILogger<DwellerServiceCommandService> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository,
            IDwellerServiceCommandRepository dwellerServiceCommandRepository,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
            _dwellerServiceCommandRepository = dwellerServiceCommandRepository;
            _dwellingQueryRepository = dwellingQueryRepository;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistService
            (AddDwellerServiceCommand cmd)
        {
            DwellerResponse<bool> response = new();

            var dwellerService = new DwellerService(cmd.Name, cmd.Description);

            var scopeSet = await dwellerService.SetServiceScope(cmd.ServiceScope);
            if (!scopeSet.IsSuccess)
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");


            if (!await _dwellerServiceCommandRepository.AddDwellerService(dwellerService))
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");

            var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(cmd.DwellingId);

            var establishProvider = new ProvidedService(dwelling, dwellerService, true);

            if (!await _dwellerServiceCommandRepository.RegisterProvidedService(establishProvider))
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");

            return await response.SuccessResponse();
        }
    }
}
