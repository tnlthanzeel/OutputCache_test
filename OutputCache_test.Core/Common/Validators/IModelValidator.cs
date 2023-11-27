using FluentValidation.Results;

namespace OutputCache_test.Core.Common.Validators;

public interface IModelValidator
{
    Task<ValidationResult> ValidateAsync<TValidator, TRequest>(TRequest request, CancellationToken token);
}