using System;
using HometaskEntity.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.BLL.DTOs
{
    public class AviatorDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirthday { get; set; }
        [Range(1, 50, ErrorMessage = "Uncorrect value")]
        [Required]
        public int Experience { get; set; }
        public Crew crew { get; set; }

    }
}
