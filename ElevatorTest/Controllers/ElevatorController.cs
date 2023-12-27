using Microsoft.AspNetCore.Mvc;
using DB;
using ElevatorApi.Contracts;

namespace ElevatorApi.Controllers
{
    [ApiController]
    [Route("api/elevator")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorService _elevatorService;

        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        [HttpGet]
        public ElevatorStatus GetElevatorStatus()
        {
            return _elevatorService.GetElevatorStatus();
        }

        [HttpPost("moveInside")]
        public IActionResult MoveInside([FromBody] int requestedFloorInside)
        {
            var response = _elevatorService.MoveInside(requestedFloorInside);
            return Ok(response);
        }

        [HttpPost("callFromFloor")]
        public IActionResult CallFromFloor([FromBody] int requestingFloorOutside)
        {
            var response = _elevatorService.CallFromFloor(requestingFloorOutside);
            return Ok(response);
        }
    }
}
