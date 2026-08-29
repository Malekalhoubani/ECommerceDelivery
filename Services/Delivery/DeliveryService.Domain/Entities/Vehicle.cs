using BuildingBlocks.SharedKernel.Entities;
using DeliveryService.Domain.Enums;

namespace DeliveryService.Domain.Entities;

public class Vehicle : AuditableEntity
{
    public string PlateNumber { get; private set; } = null!;

    public VehicleType Type { get; private set; }

    public string? Model { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsAvailable { get; private set; }
}