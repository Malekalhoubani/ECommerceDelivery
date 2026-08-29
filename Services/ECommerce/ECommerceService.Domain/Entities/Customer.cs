using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.ValueObjects;

namespace ECommerceService.Domain.Entities;

public class Customer : AuditableEntity
{
    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public Email Email { get; private set; } = null!;

    public PhoneNumber Phone { get; private set; } = null!;

    public bool IsActive { get; private set; }
}