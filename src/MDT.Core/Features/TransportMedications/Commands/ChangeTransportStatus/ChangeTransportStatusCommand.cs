using MDT.Core.Enums;
using MediatR;

namespace MDT.Core.Features.TransportMedications.Commands.ChangeTransportStatus
{
    public class ChangeTransportStatusCommand : IRequest
    {
        public int TransportId { get; set; }
        public StatusEnum DroneStatus { get; set; }
    }
}
