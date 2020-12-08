namespace FastO.Infrastructure.CQRS.Queries
{
    using FastO.Core.CQRS.Queries;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
        }

        public virtual async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(query as Query<TResponse>);
        }
    }
}
