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
        [Required]
        public Aviator aviator { get; set; }
        [Required]
        public List<Stewardess> stewardesses { get; set; }
    }
}
