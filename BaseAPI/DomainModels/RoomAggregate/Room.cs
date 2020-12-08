using FastO.Core;
using FastO.Core.DDD;
using System;
using System.ComponentModel.DataAnnotations;

namespace BaseAPI.DomainModels.RoomAggregate
{
    public class Room : Aggregate
    {
        [Key]
        public override Guid Id { get; set; } = Guid.NewGuid();

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
