using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class TypePlane
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string ModelOfPlane { get; set; }
        [Required]
        public int CountOfSeats { get; set; }
        [Required]
        public int CarryingCapacity { get; set; }
        public List<Plane> Planes { get; set; }
    }
}