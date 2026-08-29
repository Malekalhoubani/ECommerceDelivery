using DataAccess.Models;

namespace ECommerceService.Application.Models;

public class ProductFilterModel : SearchModel
{
    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public string? SortBy { get; set; }

    public string? SortDirection { get; set; }
}