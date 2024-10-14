using HahnBackendTestCRUD.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace HahnBackendTestCRUD.DTOs.Ticket
{
    public class UpdateTicketRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Description must be more than 3 caracters")]
        [MaxLength(150, ErrorMessage = "Description must be less than 150 caracters")]
        public required string Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
