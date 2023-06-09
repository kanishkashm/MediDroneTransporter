﻿using MDT.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT.Core.Entities
{
    [Table("Drone")]
    public class Drone : EntityBase
    {
        public string SerialNumber { get; set; }
        public ModelEnum Model { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
        public StatusEnum State { get; set; }
    }
}
