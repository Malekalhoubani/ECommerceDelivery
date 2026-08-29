using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace DeliveryService.Domain.Entities;

public class Driver : AuditableEntity
{
    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public PhoneNumber PhoneNumber { get; private set; } = null!;

    public string LicenseNumber { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public bool IsAvailable { get; private set; }
}