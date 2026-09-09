using DataAccess.Contexts;
using ECommerceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceService.Infrastructure.Data;

public class ECommerceDbContext : BaseDbContext
{
    public ECommerceDbContext(
        DbContextOptions<ECommerceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Value)
                    .HasColumnName("Email")
                    .HasMaxLength(256)
                    .IsRequired();
            });

        modelBuilder.Entity<Customer>()
            .OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(x => x.Value)
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsRequired();
            });

        modelBuilder.Entity<Product>()
            .OwnsOne(x => x.Price, money =>
            {
                money.Property(x => x.Amount)
                    .HasPrecision(18, 2);

                money.Property(x => x.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        modelBuilder.Entity<CartItem>()
            .OwnsOne(x => x.UnitPrice, money =>
            {
                money.Property(x => x.Amount)
                    .HasPrecision(18, 2);

                money.Property(x => x.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        modelBuilder.Entity<Order>()
            .OwnsOne(x => x.TotalAmount, money =>
            {
                money.Property(x => x.Amount)
                    .HasPrecision(18, 2);

                money.Property(x => x.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        modelBuilder.Entity<Order>()
            .OwnsOne(x => x.ShippingAddress, address =>
            {
                address.Property(x => x.City)
                    .HasMaxLength(100)
                    .IsRequired();

                address.Property(x => x.Area)
                    .HasMaxLength(100)
                    .IsRequired();

                address.Property(x => x.Street)
                    .HasMaxLength(200)
                    .IsRequired();

                address.Property(x => x.BuildingNumber)
                    .HasMaxLength(50);

                address.Property(x => x.Floor)
                    .HasMaxLength(50);

                address.Property(x => x.ApartmentNumber)
                    .HasMaxLength(50);

                address.Property(x => x.AdditionalDetails)
                    .HasMaxLength(500);
            });

        modelBuilder.Entity<OrderItem>()
            .OwnsOne(x => x.UnitPrice, money =>
            {
                money.Property(x => x.Amount)
                    .HasPrecision(18, 2);

                money.Property(x => x.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        modelBuilder.Entity<Payment>()
            .OwnsOne(x => x.Amount, money =>
            {
                money.Property(x => x.Amount)
                    .HasPrecision(18, 2);

                money.Property(x => x.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });
        modelBuilder.Entity<ProductVariant>()
          .OwnsOne(x => x.Price, money =>
    {
           money.Property(x => x.Amount)
            .HasPrecision(18, 2);

           money.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();
    });


    }
}