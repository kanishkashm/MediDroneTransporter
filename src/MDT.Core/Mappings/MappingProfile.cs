using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Features.Drones.Commands.CreateDrone;
using MDT.Core.Features.Drones.Queries.GetDroneList;
using MDT.Core.Features.Drones.ViewModel;
using MDT.Core.Features.TransportMedications.Commands.LoadMedication;

namespace MDT.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Drone, DroneVm>().ReverseMap();
            CreateMap<Drone, CreateDroneCommand>().ReverseMap();
            CreateMap<MedicationVm, Medication>().ReverseMap();
        }
    }
}
