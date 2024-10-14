using HahnBackendTestCRUD.Models.Entities.Enums;

namespace HahnBackendTestCRUD.Models.Entities;

public class Ticket
{
    public int Id { get; set; }    
    public required string Description { get; set; }
    public Status Status { get; set; }
    public DateTime Date { get; set; }
}
