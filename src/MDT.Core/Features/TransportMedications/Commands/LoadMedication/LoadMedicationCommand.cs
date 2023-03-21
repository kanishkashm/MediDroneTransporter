using MediatR;

namespace MDT.Core.Features.TransportMedications.Commands.LoadMedication
{
    public class LoadMedicationCommand : IRequest<int>
    {
        public int DroneId { get; set; }
        public List<MedicationVm> Medications { get; set; }
        public decimal TotalWeight { get; set; }
    }
}
