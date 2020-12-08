using BaseAPI.Domain.RoomAggregate;
using BaseAPI.Queries;
using FastO.Core.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public RoomController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var result = await _queryBus.Send(new GetAllRooms.Query());

            return Ok(result);
        }
    }
}
