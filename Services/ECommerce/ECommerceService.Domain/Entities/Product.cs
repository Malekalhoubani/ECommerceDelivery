using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace ECommerceService.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public Money Price { get; private set; } = null!;

    public int StockQuantity { get; private set; }

    public string? SKU { get; private set; }

    public bool IsActive { get; private set; }

    public int CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;
}