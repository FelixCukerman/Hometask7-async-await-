﻿using System;
using System.ComponentModel.DataAnnotations;
using HometaskEntity.DAL.Models;
using System.Collections.Generic;

namespace HometaskEntity.BLL.DTOs
{
    public class FlightDTO
    {
        [Required]
        [Range(100, 9999)]
        public int Number { get; set; }
        [Required]
        public string PointOfDeparture { get; set; }
        [Required]
        public DateTime TimeOfDeparture { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Destination { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public List<Ticket> ticket { get; set; }
    }
}
