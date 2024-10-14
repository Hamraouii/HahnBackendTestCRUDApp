using HahnBackendTestCRUD.DTOs.Ticket;
using HahnBackendTestCRUD.Models.Entities;

namespace HahnBackendTestCRUD.Mappings
{
    public static class TicketMapper
    {
        public static TicketDto ToTicketDto(this Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Description = ticket.Description,
                Date = ticket.Date,
                Status = ticket.Status,
            };
        }

        public static Ticket ToTicketFromCreateDTO(this CreateTicketRequestDto createTicketRequestDto) {
            return new Ticket
            {
                Description = createTicketRequestDto.Description,
                Date = createTicketRequestDto.Date,
                Status = createTicketRequestDto.Status,
            };
    }
    }
}
