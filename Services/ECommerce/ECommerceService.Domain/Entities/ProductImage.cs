using BuildingBlocks.SharedKernel.Entities;

namespace ECommerceService.Domain.Entities;

public class ProductImage : BaseEntity
{
    public int ProductId { get; private set; }

    public string ImageUrl { get; private set; } = null!;

    public bool IsPrimary { get; private set; }

    public int DisplayOrder { get; private set; }

    public Product Product { get; private set; } = null!;
}