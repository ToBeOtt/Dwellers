using Microsoft.Extensions.DependencyInjection;
using SharedKernel.ServiceResponse;

namespace SharedKernel.Infrastructure.Configuration.Queries
{
    public interface IQueryDispatcher
    {
        Task<DwellerResponse<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation);
    }
    class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<DwellerResponse<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellation);
        }
    }
}
