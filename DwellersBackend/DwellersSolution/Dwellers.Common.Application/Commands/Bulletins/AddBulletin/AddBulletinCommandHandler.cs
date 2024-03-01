using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Contracts.Commands.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Bulletins.AddBulletin
{
    public class AddBulletinCommandHandler : ICommandHandler<AddBulletinCommand, DwellerUnit>
    {
        private readonly ILogger<AddBulletinCommandHandler> _logger;
        private readonly IBulletinCommandRepository _bulletinCommandRepository;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public AddBulletinCommandHandler(
            ILogger<AddBulletinCommandHandler> logger,
            IBulletinCommandRepository bulletinCommandRepository,
            IDwellerQueryRepository dwellerQueryRepository,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _bulletinCommandRepository = bulletinCommandRepository;
            _dwellerQueryRepository = dwellerQueryRepository;
            _dwellingQueryRepository = dwellingQueryRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddBulletinCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();
            try
            {
                var dweller = await _dwellerQueryRepository.GetDwellerByIdAsync(cmd.DwellerId);
                var listOfDwellings = await _dwellingQueryRepository.GetAllDwellingsByListOfIdsAsync(cmd.ChosenDwellings);

                var bulletin = Bulletin.BulletinPostFactory.CreateNewBulletin
                    (dweller, cmd.Title, cmd.Text, cmd.BulletinTags, cmd.BulletinPriority,
                     cmd.BulletinStatus, listOfDwellings, cmd.Visibility);

                await _bulletinCommandRepository.AddBulletinAsync(bulletin);

                return await response.SuccessResponse(new DwellerUnit());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return await response.ErrorResponse
                    ("Could not create bulletin");
            }

        }
    }
}

