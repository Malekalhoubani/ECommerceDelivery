namespace BuildingBlocks.Common.Validation;

public sealed record ValidationError(string PropertyName,string Code,string Message);