using HahnBackendTestCRUD.Models.Entities.Enums;

namespace HahnBackendTestCRUD.Helpers;

public class QueryObject
{
    public Status Status { get; set; } 
    public DateOnly Date { get; set; }
    public string? SoryBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 4;


}
