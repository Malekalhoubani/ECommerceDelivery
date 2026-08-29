using BuildingBlocks.SharedKernel.Entities;
using DeliveryService.Domain.Enums;

namespace DeliveryService.Domain.Entities;

public class DeliveryStatusHistory : BaseEntity
{
    public int DeliveryId { get; private set; }

    public DeliveryStatus Status { get; private set; }

    public DateTime ChangedAt { get; private set; }

    public string? ChangedBy { get; private set; }

    public string? Notes { get; private set; }
}