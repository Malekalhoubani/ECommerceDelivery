namespace BuildingBlocks.Common.Exceptions;

public sealed class BusinessException : ApplicationExceptionBase
{
    public BusinessException(string code, string message)
        : base(code, message)
    {
    }
}