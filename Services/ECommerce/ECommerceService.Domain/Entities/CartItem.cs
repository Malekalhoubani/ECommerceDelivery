using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace ECommerceService.Domain.Entities;

public class CartItem : BaseEntity
{
    public int CartId { get; private set; }

    public int ProductId { get; private set; }

    public int Quantity { get; private set; }

    public Money UnitPrice { get; private set; } = null!;
}