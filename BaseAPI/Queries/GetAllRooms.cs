using BaseAPI.Domain.RoomAggregate;
using FastO.Core;
using FastO.Infrastructure.CQRS.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BaseAPI.Queries
{
    public class GetAllRooms
    {
        public class Query : Query<IEnumerable<Room>> { }

        public class Handler : QueryHandler<Query, IEnumerable<Room>>
        {
            private readonly IQueryRepository<Room> _queryRepository;

            public Handler(IQueryRepository<Room> queryRepository)
            {
                _queryRepository = queryRepository;
            }

            public override async Task<IEnumerable<Room>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _queryRepository.GetAllAsync();
            }
        }
    }
}
