namespace BuildingBlocks.SharedKernel.ValueObjects;

public sealed class Coordinates
{
    public double Latitude { get; private set; }

    public double Longitude { get; private set; }

    private Coordinates()
    {
    }

    public Coordinates(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentException(
                "Latitude must be between -90 and 90.");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentException(
                "Longitude must be between -180 and 180.");

        Latitude = latitude;
        Longitude = longitude;
    }
}