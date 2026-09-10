using ECommerceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceService.Infrastructure.Data.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithOne()
            .HasForeignKey<Inventory>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.AvailableQuantity)
            .IsRequired();

        builder.Property(x => x.ReservedQuantity)
            .IsRequired();
    }
}