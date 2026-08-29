namespace BuildingBlocks.SharedKernel.ValueObjects;

public sealed class Address
{
    public string City { get; private set; } = null!;

    public string Area { get; private set; } = null!;

    public string Street { get; private set; } = null!;

    public string? BuildingNumber { get; private set; }

    public string? Floor { get; private set; }

    public string? ApartmentNumber { get; private set; }

    public string? AdditionalDetails { get; private set; }

    private Address()
    {
    }

    public Address(
        string city,
        string area,
        string street,
        string? buildingNumber = null,
        string? floor = null,
        string? apartmentNumber = null,
        string? additionalDetails = null)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.");

        if (string.IsNullOrWhiteSpace(area))
            throw new ArgumentException("Area is required.");

        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required.");

        City = city;
        Area = area;
        Street = street;
        BuildingNumber = buildingNumber;
        Floor = floor;
        ApartmentNumber = apartmentNumber;
        AdditionalDetails = additionalDetails;
    }
}