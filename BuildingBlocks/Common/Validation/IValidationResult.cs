namespace BuildingBlocks.Common.Validation;

public interface IValidationResult
{
    bool IsValid { get; }

    IReadOnlyCollection<ValidationError> Errors { get; }
}