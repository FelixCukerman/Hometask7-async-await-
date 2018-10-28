using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HometaskEntity.DAL.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public int Number { get; set; }
        [Required]
        public string PointOfDeparture { get; set; }
        [Required]
        public DateTime TimeOfDeparture { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Departure> Departures { get; set; }
    }
}
