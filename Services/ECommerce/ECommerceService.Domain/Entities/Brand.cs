using BuildingBlocks.SharedKernel.Entities;

namespace ECommerceService.Domain.Entities;

public class Brand : AuditableEntity
{
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }
    public ICollection<Product> Products { get; private set; }= new List <Product>();
}