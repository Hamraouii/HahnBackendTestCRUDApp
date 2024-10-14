using HahnBackendTestCRUD.Data;
using HahnBackendTestCRUD.DTOs.Ticket;
using HahnBackendTestCRUD.Helpers;
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

        public async Task<List<Ticket>> GetAllAsync(QueryObject query)
        {
            var tickets = _ticketDbContext.Tickets.AsQueryable();

            if (query.Status != 0)
            {
                tickets = tickets.Where(t => t.Status == query.Status);
            }

            if (query.Date != default)
            {
                tickets = tickets.Where(t => t.Date == query.Date);
            }

            if (!string.IsNullOrEmpty(query.SoryBy))
            {
                if (query.SoryBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                {
                    tickets = query.IsDescending ? tickets.OrderByDescending(s => s.Date) : tickets.OrderBy(s=>s.Date);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await tickets.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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
