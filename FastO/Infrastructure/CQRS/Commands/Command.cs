using FastO.Core.CQRS.Commands;
using MediatR;

namespace FastO.Infrastructure.CQRS.Commands
{
    public class Command : ICommand, IRequest
    {
    }

    public class Command<TResponse> : ICommand<TResponse>, IRequest<TResponse>
    {
    }
}
