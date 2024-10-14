using HahnBackendTestCRUD.Data;
using HahnBackendTestCRUD.DTOs.Ticket;
using HahnBackendTestCRUD.Interfaces;
using HahnBackendTestCRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnBackendTestCRUD.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _ticketDbContext;
        public TicketRepository(TicketDbContext context) 
        {
            _ticketDbContext = context;
        }

        public Task<List<Ticket>> GetAllAsync()
        {
            return _ticketDbContext.Tickets.ToListAsync();
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            await _ticketDbContext.Tickets.AddAsync(ticket);
            await _ticketDbContext.SaveChangesAsync();
            return ticket;
            
        }

        public async Task<Ticket> DeleteAsync(int id)
        {
            var ticket = await _ticketDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null)
            {
                return null;
            }

            _ticketDbContext.Tickets.Remove(ticket);
            await _ticketDbContext.SaveChangesAsync();
            return ticket;
        }

        

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _ticketDbContext.Tickets.FindAsync(id);
        }

        public async Task<Ticket?> UpdateAsync(int id, UpdateTicketRequestDto ticketDto)
        {
            var existingTickets = await _ticketDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTickets == null)
            {
                return null;
            }
            existingTickets.Status = ticketDto.Status;
            existingTickets.Description = ticketDto.Description;
            existingTickets.Date = ticketDto.Date;

            await _ticketDbContext.SaveChangesAsync();

            return existingTickets;

        }
    }
}
