﻿using System;

namespace API.Domain.Models
{
    public class ConnectorModel
    {
        public Guid Id { get; set; }
        public decimal MaxCurrent { get; set; }
        public Guid ChargeStationId { get; set; }
    }
}