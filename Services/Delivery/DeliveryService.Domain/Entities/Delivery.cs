using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;
using DeliveryService.Domain.Enums;

namespace DeliveryService.Domain.Entities;

public class Delivery : AuditableEntity
{
    public int OrderId { get; private set; }

    public int? DriverId { get; private set; }

    public int? VehicleId { get; private set; }

    public DeliveryStatus Status { get; private set; }

    public Address DeliveryAddress { get; private set; } = null!;

    public Coordinates? Coordinates { get; private set; }

    public DateTime? AssignedAt { get; private set; }

    public DateTime? PickedUpAt { get; private set; }

    public DateTime? DeliveredAt { get; private set; }
}