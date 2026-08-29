using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace ECommerceService.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int OrderId { get; private set; }

    public int ProductId { get; private set; }

    public string ProductName { get; private set; } = null!;

    public Money UnitPrice { get; private set; } = null!;

    public int Quantity { get; private set; }
}