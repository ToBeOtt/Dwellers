using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Infrastructure.Configuration.Queries
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TQueryResult> GetHandler<TQuery, TQueryResult>();
    }

    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQueryHandler<TQuery, TQueryResult> GetHandler<TQuery, TQueryResult>()
        {
            return _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
        }
    }
}
