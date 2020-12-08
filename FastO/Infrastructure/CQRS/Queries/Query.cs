namespace FastO.Infrastructure.CQRS.Queries
{
    using FastO.Core.CQRS.Queries;
    using MediatR;

    public class Query<TResponse> : IQuery<TResponse>, IRequest<TResponse>
    {
    }
}
