using MDT.Core.Enums;
using MDT.Core.Features.Drones.Commands.CreateDrone;
using MDT.Core.Features.Drones.Commands.MakeDroneAvailable;
using MDT.Core.Features.Drones.Commands.UpdateDrone;
using MDT.Core.Features.Drones.Commands.UpdateDroneStatus;
using MDT.Core.Features.Drones.Queries.AvailableDrones;
using MDT.Core.Features.Drones.Queries.GetDrone;
using MDT.Core.Features.Drones.Queries.GetDroneList;
using MDT.Core.Features.Drones.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DroneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllDrones")]
        [ProducesResponseType(typeof(IEnumerable<List<DroneVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DroneVm>> GetAllDrones()
        {
            var query = new GetDronesListQuery();
            var droneList = await _mediator.Send(query);
            return Ok(droneList);
        }

        [HttpGet("{serialNumber}", Name = "GetDrone")]
        [ProducesResponseType(typeof(IEnumerable<DroneVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DroneVm>> GetDrone(string serialNumber)
        {
            var query = new GetDroneQuery(serialNumber);
            var drone = await _mediator.Send(query);
            return Ok(drone);
        }

        [HttpGet("AvailableDrones")]
        [ProducesResponseType(typeof(IEnumerable<List<DroneVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DroneVm>> AvailableDrones()
        {
            var query = new AvailableDronesQuery(StatusEnum.IDLE);
            var droneList = await _mediator.Send(query);
            return Ok(droneList);
        }

        [HttpPost(Name = "RegisterDrone")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RegisterDrone([FromBody] CreateDroneCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateDroneBattery")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateDroneBattery([FromBody] UpdateDroneBatteryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("MakeDroneAvailable")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> MakeDroneAvailable([FromBody] MakeDroneAvailableCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
