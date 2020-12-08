using BaseAPI.DomainModels.RoomAggregate;
using FastO.Core.Persistence;
using FastO.Helper.Api;
using FastO.Infrastructure.CQRS.Commands;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaseAPI.Cqrs.Commands
{
    public class CreateRoom
    {
        public class Command : Command<Result>
        {
            public int Code { get; set; }
            public string Name { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(cmd => cmd.Name).NotEmpty();
                RuleFor(cmd => cmd.Code).NotEmpty();
            }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : CommandHandler<Command, Result>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public override async Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                var room = command.Map<Command, Room>();

                return new Result
                {
                    Id = await _uof.GetRepository<Room>().AddAsync(room)
                };
            }
        }
    }
}
