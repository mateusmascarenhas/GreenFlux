﻿using System;

namespace API.Presentation.DTO
{
    public class ConnectorDTO
    {
        public Guid Id { get; set; }
        public decimal MaxCurrent { get; set; }
        public Guid ChargeStationId { get; set; }
    }
}