using FastO.Core.CQRS.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.CQRS.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
        }

        public async Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command as Command<TResponse>);
        }

        public async Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command as Command);
        }
    }
}
