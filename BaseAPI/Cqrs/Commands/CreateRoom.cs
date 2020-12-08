using AutoMapper;
using BaseAPI.DomainModels.RoomAggregate;
using FastO.Core.Persistence;
using FastO.Infrastructure.CQRS.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaseAPI.Cqrs.Commands
{
    public class CreateRoom
    {
        public class Command : Command<Result> {
            public int Code { get; set; }
            public string Name { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : CommandHandler<Command, Result>
        {
            private readonly IUnitOfWork _uof;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uof, IMapper mapper)
            {
                _mapper = mapper;
                _uof = uof;
            }

            public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var room = _mapper.Map<Room>(request);
                var id = await _uof.GetRepository<Room>().AddAsync(room);

                return new Result
                {
                    Id = id
                };
            }
        }
    }
}
