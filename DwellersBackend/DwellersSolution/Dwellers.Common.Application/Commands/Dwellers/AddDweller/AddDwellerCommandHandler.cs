using Dwellers.Common.Application.Contracts.Commands.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Dwellers.AddDweller
{
    public class AddDwellerCommandHandler : ICommandHandler<AddDwellerCommand, DwellerUnit>
    {
        private readonly ILogger<AddDwellerCommandHandler> _logger;
        private readonly IDwellerCommandRepository _dwellerCommandRepository;

        public AddDwellerCommandHandler(
            ILogger<AddDwellerCommandHandler> logger,
            IDwellerCommandRepository dwellerCommandRepository)
        {
            _logger = logger;
            _dwellerCommandRepository = dwellerCommandRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddDwellerCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dweller = await Dweller.DwellerFactory.Create(cmd.DwellerId, cmd.Alias, cmd.Email);

            if (await _dwellerCommandRepository.AddDwellerAsync(dweller))
                return await response.SuccessResponse(new DwellerUnit());

            else
                return await response.ErrorResponse
                       ("Could not add dweller");
        }
    }
}
