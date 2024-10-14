using HahnBackendTestCRUD.Models.Entities.Enums;

namespace HahnBackendTestCRUD.DTOs.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
    }
}
