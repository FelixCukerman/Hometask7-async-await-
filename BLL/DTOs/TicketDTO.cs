using System.ComponentModel.DataAnnotations;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.BLL.DTOs
{
    public class TicketDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Range(100, 9999)]
        public Ticket ticket { get; set; }
    }
}
