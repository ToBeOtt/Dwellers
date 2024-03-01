using Dwellers.Common.Application.Contracts.Commands.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.Common.Application.Commands.Dwellings.AttachDwellingToDweller
{
    public class AttachDwellingToDwellerCommandHandler
        : ICommandHandler<AttachDwellingToDwellerCommand, AttachDwellingToDwellerResult>
    {
        private readonly ILogger<AttachDwellingToDwellerCommandHandler> _logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;
        private readonly IDwellingCommandRepository _dwellingCommandRepository;

        public AttachDwellingToDwellerCommandHandler(
            ILogger<AttachDwellingToDwellerCommandHandler> logger,
            IDwellerQueryRepository dwellerQueryRepository,
            IDwellingCommandRepository dwellingCommandRepository)
        {
            _logger = logger;
            _dwellerQueryRepository = dwellerQueryRepository;
            _dwellingCommandRepository = dwellingCommandRepository;
        }
        public async Task<DwellerResponse<AttachDwellingToDwellerResult>> Handle
            (AttachDwellingToDwellerCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<AttachDwellingToDwellerResult> response = new();
            try
            {
                var dwelling = await DwellingFactory.Create(cmd.Name, cmd.Description);
                if (dwelling == null)
                    return await response.ErrorResponse("Dwelling not found.");

                var dweller = await _dwellerQueryRepository.GetDwellerByEmailAsync(cmd.Email);
                if (dweller == null)
                    return await response.ErrorResponse("Dweller not found.");

                await _dwellingCommandRepository.AddDwellingAsync(dwelling);

                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create(dwelling, dweller);

                await _dwellingCommandRepository.AddDwellerInhabitantAsync(dwellingInhabitant);

                return await response.SuccessResponse
                     (new AttachDwellingToDwellerResult(
                      Name: dwelling.Name,
                      DwellingId: dwelling.Id));
            }

            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);

                return await response.ErrorResponse
                    ("Dwelling could not be coupled with dweller.");
            }
        }
    }
}
