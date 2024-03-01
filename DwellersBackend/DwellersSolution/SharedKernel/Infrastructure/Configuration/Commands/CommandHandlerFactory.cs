using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Infrastructure.Configuration.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand, TCommandResult> GetHandler<TCommand, TCommandResult>();
    }

    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandHandler<TCommand, TCommandResult> GetHandler<TCommand, TCommandResult>()
        {
            return _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        }

    }

}
