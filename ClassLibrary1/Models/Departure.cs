using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class Departure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public Flight FlightObj { get; set; }
        [Required]
        public int TimeOfDeparture { get; set; }
        public Crew CrewObj { get; set; }
        public Plane PlaneObj { get; set; }
    }
}
