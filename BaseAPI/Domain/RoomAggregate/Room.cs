using FastO.Core;

namespace BaseAPI.Domain.RoomAggregate
{
    public class Room : Aggregate
    {
        public int Code { get; set; }

        public string Name { get; set; }
    }
}
