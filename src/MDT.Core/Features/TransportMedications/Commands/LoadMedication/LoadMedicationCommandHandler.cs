using AutoMapper;
using MDT.Core.Entities;
using MDT.Core.Enums;
using MDT.Core.Exceptions;
using MDT.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MDT.Core.Features.TransportMedications.Commands.LoadMedication
{
    public class LoadMedicationCommandHandler : IRequestHandler<LoadMedicationCommand, int>
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IDeliveryDetailsRepository _deliveryDetailsRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoadMedicationCommandHandler> _logger;
        private readonly IConfiguration _configuration;

        public LoadMedicationCommandHandler
            (
                IDroneRepository droneRepository,
                IDeliveryDetailsRepository deliveryDetailsRepository,
                IMedicationRepository medicationRepository,
                IMapper mapper,
                ILogger<LoadMedicationCommandHandler> logger,
                IConfiguration configuration
            )
        {
            _droneRepository = droneRepository;
            _deliveryDetailsRepository = deliveryDetailsRepository;
            _medicationRepository = medicationRepository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<int> Handle(LoadMedicationCommand request, CancellationToken cancellationToken)
        {
            var droneDetails = await _droneRepository.GetByIdAsync(request.DroneId);
            LoadValidation(droneDetails, request);

            droneDetails.State = StatusEnum.LOADING;
            await _droneRepository.UpdateAsync(droneDetails);

            var deliveryDetails = new DeliveryDetails
            {
                DroneId = request.DroneId,
                DateTimeStarted = DateTime.UtcNow,
                DroneStatus = StatusEnum.LOADING
            };

            await _deliveryDetailsRepository.AddAsync(deliveryDetails);

            foreach (var medication in request.Medications)
            {
                var medicationToSave = new Medication();
                _mapper.Map(medication, medicationToSave, typeof(MedicationVm), typeof(Medication));
                medicationToSave.DeliveryDetailsId = deliveryDetails.Id;
                await _medicationRepository.AddAsync(medicationToSave);
            }
            return deliveryDetails.Id;
        }

        public void LoadValidation(Drone droneDetails, LoadMedicationCommand request)
        {
            if (droneDetails == null)
            {
                _logger.LogError("Drone not exist on database.");
                throw new NotFoundException(nameof(Drone), request.DroneId);
            }
            if (droneDetails.State != StatusEnum.IDLE)
            {
                _logger.LogError("Drone is not available at this momment.");
                throw new NotAvailableException(nameof(Drone), request.DroneId);
            }
            request.TotalWeight = request.Medications.Sum(x => x.Weight);
            if (droneDetails.WeightLimit <= request.TotalWeight)
            {
                _logger.LogError("Drone was loaded with more weight that it can carry.");
                throw new Exception("Drone was loaded with more weight that it can carry.");
            }
            if (droneDetails.BatteryCapacity < 25)
            {
                _logger.LogError("Drone can't be loaded because battery is low.");
                throw new Exception("Drone can't be loaded because battery is low.");
            }

            //foreach (var medication in request.Medications)
            //{
            //    if()
            //}
        }
    }
}
