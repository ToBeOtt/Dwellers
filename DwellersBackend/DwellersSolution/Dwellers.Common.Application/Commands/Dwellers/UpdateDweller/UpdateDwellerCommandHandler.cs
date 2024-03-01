using Dwellers.Common.Application.Contracts.Commands.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Dwellers.UpdateDweller
{
    public class SetDwellerProfilePhotoCommandHandler : ICommandHandler<SetDwellerProfilePhotoCommand, DwellerUnit>
    {
        private readonly ILogger<SetDwellerProfilePhotoCommandHandler> _logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;

        public SetDwellerProfilePhotoCommandHandler(
            ILogger<SetDwellerProfilePhotoCommandHandler> logger,
            IDwellerQueryRepository dwellerQueryRepository)
        {
            _logger = logger;
            _dwellerQueryRepository = dwellerQueryRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (SetDwellerProfilePhotoCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dweller = await _dwellerQueryRepository.GetDwellerByIdAsync(cmd.DwellerId);
            if (dweller is null)
                return await response.ErrorResponse
                    ("User could not be found.");

            if(await dweller.SetProfilePhoto(cmd.DwellerPhoto))
                return await response.SuccessResponse(new DwellerUnit());

            else
                return await response.ErrorResponse
                  ("An error occurred while updating the profile-photo.");

        }
    }
}
