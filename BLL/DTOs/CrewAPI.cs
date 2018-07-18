using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HometaskEntity.DAL.Models;

namespace BLL.DTOs
{
    class CrewAPI
    {
        [Required]
        public int id { get; set; }
        [Required]
        public List<Aviator> pilot { get; set; }
        [Required]
        public List<Stewardess> stewardess { get; set; }
    }
}