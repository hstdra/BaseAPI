using System.Threading;
using System.Threading.Tasks;

namespace FastO.Core.CQRS.Queries
{
    public interface IQueryBus
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}
