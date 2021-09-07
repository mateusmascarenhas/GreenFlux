﻿using System;
using System.Collections.Generic;

namespace API.Domain.Models
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Capacity { get; set; }
        public ICollection<ChargeStationModel> ChargeStations { get; set; }
    }
}