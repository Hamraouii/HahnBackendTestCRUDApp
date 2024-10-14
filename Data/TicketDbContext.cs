using HahnBackendTestCRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnBackendTestCRUD.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

    }
}
