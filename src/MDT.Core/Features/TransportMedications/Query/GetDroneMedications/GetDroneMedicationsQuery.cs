using MDT.Core.Features.TransportMedications.Commands.LoadMedication;
using MediatR;

namespace MDT.Core.Features.TransportMedications.Query.GetDroneMedications
{
    public class GetDroneMedicationsQuery : IRequest<List<MedicationVm>>
    {
        public string SerialNumber { get; set; }

        public GetDroneMedicationsQuery(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
