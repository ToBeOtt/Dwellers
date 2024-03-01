using Microsoft.Extensions.DependencyInjection;
using SharedKernel.ServiceResponse;

namespace SharedKernel.Infrastructure.Configuration.Commands
{
    public interface ICommandDispatcher
    {
        Task<DwellerResponse<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation);
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<DwellerResponse<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
            var result = await handler.Handle(command, cancellation);

            var response = new DwellerResponse<TCommandResult>();
            return await response.SuccessResponse();
        }
    }
}

