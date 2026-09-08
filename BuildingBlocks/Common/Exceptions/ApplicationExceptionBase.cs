namespace BuildingBlocks.Common.Exceptions;

public class ApplicationExceptionBase : Exception, IApplicationException
{
    public string Code { get; }

    public ApplicationExceptionBase(string code, string message)
        : base(message)
    {
        Code = code;
    }
}