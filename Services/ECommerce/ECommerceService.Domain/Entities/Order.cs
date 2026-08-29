using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;
using ECommerceService.Domain.Enums;

namespace ECommerceService.Domain.Entities;

public class Order : AuditableEntity
{
    public int CustomerId { get; private set; }

    public DateTime OrderDate { get; private set; }

    public OrderStatus Status { get; private set; }

    public Money TotalAmount { get; private set; } = null!;

    public Address ShippingAddress { get; private set; } = null!;
}