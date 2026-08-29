namespace BuildingBlocks.SharedKernel.ValueObjects;

public sealed class PhoneNumber
{
    public string Value { get; private set; } = null!;

    private PhoneNumber()
    {
    }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number is required.");

        if (value.Length < 8 || value.Length > 15)
            throw new ArgumentException("Invalid phone number.");

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}