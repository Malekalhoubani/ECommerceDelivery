using DataAccess.Models;
using ECommerceService.Domain.Enums;

namespace ECommerceService.Application.Models;

public class ProductFilterModel : SearchModel
{
    public int? CategoryId { get; set; }

    public ProductStatus? Status { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public string? SortBy { get; set; }

    public string? SortDirection { get; set; }
}