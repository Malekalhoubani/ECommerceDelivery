using ECommerceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceService.Infrastructure.Data.Configurations;

public class StockHistoryConfiguration : IEntityTypeConfiguration<StockHistory>
{
    public void Configure(EntityTypeBuilder<StockHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Inventory)
            .WithMany()
            .HasForeignKey(x => x.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.TransactionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Notes)
            .HasMaxLength(500);
    }
}