using BuildingBlocks.SharedKernel.Entities;

namespace ECommerceService.Domain.Entities;

public class Cart : AuditableEntity
{
    public int CustomerId { get; private set; }
}