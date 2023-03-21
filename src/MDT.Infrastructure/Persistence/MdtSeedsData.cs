using MDT.Core.Entities;
using MDT.Core.Enums;

namespace MDT.Infrastructure.Persistence
{
    public static class MdtSeedsData
    {
        public static void Initialize(MdtContext context)
        {
            context.Database.EnsureCreated();

            var drones = new List<Drone>
            {
                new Drone
                {
                    SerialNumber = "ABC300631253686",
                    Model = ModelEnum.Lightweight,
                    WeightLimit = 250,
                    State = StatusEnum.IDLE,
                    BatteryCapacity = 67
                },
                new Drone
                {
                    SerialNumber = "DRN781709233746",
                    Model = ModelEnum.Heavyweight,
                    WeightLimit = 500,
                    State = StatusEnum.IDLE,
                    BatteryCapacity = 80
                },
                new Drone
                {
                    SerialNumber = "DRN447923720350",
                    Model = ModelEnum.Cruiserweight,
                    WeightLimit = 450,
                    State = StatusEnum.IDLE,
                    BatteryCapacity = 70
                },
                new Drone
                {
                    SerialNumber = "DRN571313111301",
                    Model = ModelEnum.Middleweight,
                    WeightLimit = 450,
                    State = StatusEnum.IDLE,
                    BatteryCapacity = 56
                },
                new Drone
                {
                    SerialNumber = "DRN301281343369",
                    Model = ModelEnum.Heavyweight,
                    WeightLimit = 495,
                    State = StatusEnum.IDLE,
                    BatteryCapacity = 80
                }
            };

            foreach (var drone in drones)
            {
                context.Drones.Add(drone);
            }

            context.SaveChanges();

        }
    }
}
