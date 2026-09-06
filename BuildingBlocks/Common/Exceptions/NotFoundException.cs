using Common.Exceptions;

namespace BuildingBlocks.Common.Exceptions;

public sealed class NotFoundException : ApplicationExceptionBase
{
    public NotFoundException(string entityName,object id): base($"{entityName}.NotFound",$"{entityName} with id '{id}' was not found.")
    {
    }
}