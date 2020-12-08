using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.CQRS.Queries
{
    public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Query<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
