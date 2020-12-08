using AutoMapper;
using BaseAPI.Cqrs.Commands;
using BaseAPI.Cqrs.Queries;
using BaseAPI.DomainModels.RoomAggregate;

namespace BaseAPI.Extensions
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateRoom.Command, Room>();
            CreateMap<Room, GetAllRooms.Result>();
        }
    }
}
