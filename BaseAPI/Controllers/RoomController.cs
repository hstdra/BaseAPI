using BaseAPI.Cqrs.Commands;
using BaseAPI.Cqrs.Queries;
using FastO.Core.CQRS.Commands;
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
        private readonly ICommandBus _commandBus;

        public RoomController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllRooms.Result>>> GetRooms()
        {
            var result = await _queryBus.Send(new GetAllRooms.Query());

            return Ok(result);
        }

        /// <summary>
        /// CreateRoom
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateRoom.Result>> CreateRoom([FromBody] CreateRoom.Command command)
        {
            var result = await _commandBus.Send(command);

            return Created(string.Empty, result);
        }
    }
}
