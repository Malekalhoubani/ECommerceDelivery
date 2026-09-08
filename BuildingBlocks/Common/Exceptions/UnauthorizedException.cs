namespace BuildingBlocks.Common.Exceptions;

public sealed class UnauthorizedException : ApplicationExceptionBase
{
    public UnauthorizedException(
        string code = "Authorization.Unauthorized",
        string message = "You are not authorized to perform this action.")
        : base(code, message)
    {
    }
}