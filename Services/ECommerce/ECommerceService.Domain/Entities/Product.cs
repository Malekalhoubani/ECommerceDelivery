using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;
using ECommerceService.Domain.Enums;

namespace ECommerceService.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public Money Price { get; private set; } = null!;

    public int StockQuantity { get; private set; }

    public string? SKU { get; private set; }

    public ProductStatus Status { get; private set; }

    public int CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;
    public int? BrandId { get; private set; }

    public Brand? Brand { get; private set; }
    private Product()
    {
    }

    public Product(string name,string? description,Money price,int stockQuantity,string? sku,int categoryId ,int? brandId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");

        if (price is null)
            throw new ArgumentNullException(nameof(price));

        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.");

        if (categoryId <= 0)
            throw new ArgumentException("Category is required.");

        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        SKU = sku;
        CategoryId = categoryId;
        BrandId = brandId;
        Status = stockQuantity == 0
            ? ProductStatus.OutOfStock
            : ProductStatus.Active;
    }

    public void Update(string name,string? description,Money price,int stockQuantity,string? sku,int categoryId ,int? brandId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");

        if (price is null)
            throw new ArgumentNullException(nameof(price));

        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.");

        if (categoryId <= 0)
            throw new ArgumentException("Category is required.");

        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        SKU = sku;
        CategoryId = categoryId;
        BrandId = brandId;
        Status = stockQuantity == 0
            ? ProductStatus.OutOfStock
            : ProductStatus.Active;
    }
}