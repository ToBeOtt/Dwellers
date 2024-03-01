using Dwellers.Common.Application.Contracts.Commands.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Commands.Dwellings.AttachDwellerToDwelling
{
    public class AttachDwellerToDwellingCommandHandler
        : ICommandHandler<AttachDwellerToDwellingCommand, AttachDwellerToDwellingResult>
    {
        private readonly ILogger<AttachDwellerToDwellingCommandHandler> _logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;
        private readonly IDwellingCommandRepository _dwellingCommandRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public AttachDwellerToDwellingCommandHandler(
            ILogger<AttachDwellerToDwellingCommandHandler> logger,
            IDwellerQueryRepository dwellerQueryRepository,
            IDwellingCommandRepository dwellingCommandRepository,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _dwellerQueryRepository = dwellerQueryRepository;
            _dwellingCommandRepository = dwellingCommandRepository;
            _dwellingQueryRepository = dwellingQueryRepository;
        }
        public async Task<DwellerResponse<AttachDwellerToDwellingResult>> Handle
            (AttachDwellerToDwellingCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<AttachDwellerToDwellingResult> response = new();
            try
            {
                var dweller = await _dwellerQueryRepository.GetDwellerByEmailAsync(cmd.Email);

                var dwelling = await _dwellingQueryRepository.GetDwellingByIdAsync(cmd.Invitation); // WRONG

                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create
                    (dwelling, dweller);

                await _dwellingCommandRepository.AddDwellerInhabitantAsync(dwellingInhabitant);

                return await response.SuccessResponse
                    (new AttachDwellerToDwellingResult(
                      Name: dwelling.Name,
                      Alias: dweller.Alias));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while executing AttachDwellerToDwellingHandler: {ex.Message}", ex.Message);
                return await response.ErrorResponse("Dweller could not be attached to dwelling.");
            }
        }
    }
}