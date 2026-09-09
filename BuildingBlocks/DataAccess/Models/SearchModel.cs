namespace DataAccess.Models;

public class SearchModel : PaginationParams
{
    public string? SearchTerm { get; set; }
}