using SharedKernel.ServiceResponse;

namespace SharedKernel.Infrastructure.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TQueryResult>
    {
        Task<DwellerResponse<TQueryResult>> Handle(TQuery query, CancellationToken cancellation);
    }
}
