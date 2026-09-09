using DataAccess.Specifications;
using ECommerceService.Application.Models;
using ECommerceService.Domain.Entities;

namespace ECommerceService.Application.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductFilterModel filter)
        : base(x =>
            (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId.Value) &&
            (!filter.Status.HasValue || x.Status == filter.Status.Value) &&
            (!filter.MinPrice.HasValue || x.Price.Amount >= filter.MinPrice.Value) &&
            (!filter.MaxPrice.HasValue || x.Price.Amount <= filter.MaxPrice.Value) &&
            (string.IsNullOrWhiteSpace(filter.SearchTerm) ||
             x.Name.Contains(filter.SearchTerm)))
    {
        AddInclude(x => x.Category);

        switch (filter.SortBy?.ToLower())
        {
            case "name":
                if (filter.SortDirection?.ToLower() == "desc")
                    ApplyOrderByDescending(x => x.Name);
                else
                    ApplyOrderBy(x => x.Name);
                break;

            case "price":
                if (filter.SortDirection?.ToLower() == "desc")
                    ApplyOrderByDescending(x => x.Price.Amount);
                else
                    ApplyOrderBy(x => x.Price.Amount);
                break;

            case "stock":
                if (filter.SortDirection?.ToLower() == "desc")
                    ApplyOrderByDescending(x => x.StockQuantity);
                else
                    ApplyOrderBy(x => x.StockQuantity);
                break;

            default:
                ApplyOrderBy(x => x.Name);
                break;
        }
    }
}