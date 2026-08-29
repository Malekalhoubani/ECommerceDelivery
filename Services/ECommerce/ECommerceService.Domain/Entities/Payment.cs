using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;
using ECommerceService.Domain.Enums;

namespace ECommerceService.Domain.Entities;

public class Payment : AuditableEntity
{
    public int OrderId { get; private set; }

    public Money Amount { get; private set; } = null!;

    public PaymentMethod Method { get; private set; }

    public PaymentStatus Status { get; private set; }

    public string? TransactionId { get; private set; }

    public DateTime? PaidAt { get; private set; }
}