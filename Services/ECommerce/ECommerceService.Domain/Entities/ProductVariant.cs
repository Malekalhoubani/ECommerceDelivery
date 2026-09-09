using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace ECommerceService.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public int ProductId { get; private set; }

    public string Name { get; private set; } = null!;

    public string? SKU { get; private set; }

    public Money Price { get; private set; } = null!;

    public int StockQuantity { get; private set; }

    public bool IsActive { get; private set; }

    public Product Product { get; private set; } = null!;
}