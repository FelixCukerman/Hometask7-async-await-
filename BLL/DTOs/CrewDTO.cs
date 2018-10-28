using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HometaskEntity.DAL.Models;


namespace HometaskEntity.BLL.DTOs
{
    public class CrewDTO
    {
        [Required]
        public int Id { get; set; }
        public List<Aviator> aviator { get; set; }
        public List<Stewardess> stewardesses { get; set; }
        public List<Departure> departures { get; set; }
    }
}
