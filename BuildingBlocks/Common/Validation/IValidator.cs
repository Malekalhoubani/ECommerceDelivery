namespace BuildingBlocks.Common.Validation;

public interface IValidator<in T>
{
    Task<ValidationResult> ValidateAsync(T instance,CancellationToken cancellationToken = default);
}