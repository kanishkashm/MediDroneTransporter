using MDT.Core.Features.TransportMedications.Commands.ChangeTransportStatus;
using MDT.Core.Features.TransportMedications.Commands.LoadMedication;
using MDT.Core.Features.TransportMedications.Query.GetDroneMedications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportMedicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportMedicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "LoadDrone")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> LoadDrone([FromBody] LoadMedicationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("ChangeLoadStatus")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ChangeLoadStatus([FromBody] ChangeTransportStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetDroneMedications")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetDroneMedications(string serialNumber)
        {
            var query = new GetDroneMedicationsQuery(serialNumber);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
