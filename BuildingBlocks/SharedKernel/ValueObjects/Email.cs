namespace BuildingBlocks.SharedKernel.ValueObjects;

public sealed class Email
{
    public string Value { get; private set; } = null!;

    private Email()
    {
    }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required.");

        if (!value.Contains("@"))
            throw new ArgumentException("Invalid email format.");

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}