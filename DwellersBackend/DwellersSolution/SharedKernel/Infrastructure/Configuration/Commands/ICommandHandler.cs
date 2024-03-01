using SharedKernel.ServiceResponse;

namespace SharedKernel.Infrastructure.Configuration.Commands
{
    public interface ICommandHandler<TCommand, TCommandResult>
    {
        Task<DwellerResponse<TCommandResult>> Handle(TCommand command, CancellationToken cancellation);
    }
}
