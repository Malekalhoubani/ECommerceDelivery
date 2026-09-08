namespace BuildingBlocks.Common.Exceptions;

public sealed class DatabaseException : ApplicationExceptionBase
{
    public DatabaseException(string code, string message)
        : base(code, message)
    {
    }
}