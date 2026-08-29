using DataAccess.Contexts;
using DeliveryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Infrastructure.Data;

public class DeliveryDbContext : BaseDbContext
{
    public DeliveryDbContext(
        DbContextOptions<DeliveryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Delivery> Deliveries => Set<Delivery>();
    public DbSet<DeliveryStatusHistory> DeliveryStatusHistories => Set<DeliveryStatusHistory>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Delivery>()
            .OwnsOne(x => x.DeliveryAddress, address =>
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

        modelBuilder.Entity<Delivery>()
            .OwnsOne(x => x.Coordinates, coordinates =>
            {
                coordinates.Property(x => x.Latitude)
                    .HasColumnName("Latitude");

                coordinates.Property(x => x.Longitude)
                    .HasColumnName("Longitude");
            });

        modelBuilder.Entity<Driver>()
            .OwnsOne(x => x.PhoneNumber, phone =>
            {
                phone.Property(x => x.Value)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(15)
                    .IsRequired();
            });
    }
}