using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.CQRS.Commands
{
    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest : Command
    {
        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Command<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
