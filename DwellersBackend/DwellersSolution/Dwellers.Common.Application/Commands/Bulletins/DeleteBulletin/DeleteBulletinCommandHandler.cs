using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Contracts.Commands.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Bulletins.DeleteBulletin
{
    public class DeleteBulletinCommandHandler : ICommandHandler<DeleteBulletinCommand, DwellerUnit>
    {
        private readonly ILogger<DeleteBulletinCommandHandler> _logger;
        private readonly IBulletinQueryRepository _bulletinRepo;
        private readonly IBulletinCommandRepository _bulletinCommandRepository;

        public DeleteBulletinCommandHandler(
            ILogger<DeleteBulletinCommandHandler> logger,
            IBulletinQueryRepository bulletinRepo,
            IBulletinCommandRepository bulletinCommandRepository)
        {
            _logger = logger;
            _bulletinRepo = bulletinRepo;
            _bulletinCommandRepository = bulletinCommandRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle(DeleteBulletinCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var bulletin = await _bulletinRepo.GetByIdAsync(cmd.Id);

            bulletin.ArchiveBulletin(bulletin);

            if (!await _bulletinCommandRepository.DeleteBulletinAsync(bulletin))
                return await response.ErrorResponse
                    ("Could not persist entity.");

            return await response.SuccessResponse(new DwellerUnit());
        }
    }
}
