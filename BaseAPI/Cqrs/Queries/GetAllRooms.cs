using AutoMapper;
using BaseAPI.DomainModels.RoomAggregate;
using FastO.Core.Persistence;
using FastO.Helper.Api;
using FastO.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BaseAPI.Cqrs.Queries
{
    public class GetAllRooms
    {
        public class Query : Query<IEnumerable<Result>> { }

        public class Result
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class Handler : QueryHandler<Query, IEnumerable<Result>>
        {
            private readonly IRepository<Room> _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository<Room> queryRepository, IMapper mapper)
            {
                _repository = queryRepository;
                _mapper = mapper;
            }

            public override async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rooms = await _repository.GetAllAsync();

                return rooms.Select(Mapping.Map<Room, Result>).ToList();
                //return rooms.Select(room => _mapper.Map<Room, Result>(room)).ToList();
            }
        }
    }
}
