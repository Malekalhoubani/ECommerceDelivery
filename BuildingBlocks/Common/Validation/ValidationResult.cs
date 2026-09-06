namespace BuildingBlocks.Common.Validation;

public sealed class ValidationResult : IValidationResult
{
    public ValidationResult(IReadOnlyCollection<ValidationError> errors)
    {
        Errors = errors;
    }

    public bool IsValid => Errors.Count == 0;

    public IReadOnlyCollection<ValidationError> Errors { get; }
}