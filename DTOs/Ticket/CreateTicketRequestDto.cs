using HahnBackendTestCRUD.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace HahnBackendTestCRUD.DTOs.Ticket
{
    public class CreateTicketRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Description must be more than 3 caracters")]
        [MaxLength(150, ErrorMessage = "Description must be less than 150 caracters")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }
}
