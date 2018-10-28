using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class Crew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public List<Aviator> Aviators { get; set; }
        public List<Stewardess> Stewardesses { get; set; }
        public List<Departure> Departures { get; set; }
    }
}
