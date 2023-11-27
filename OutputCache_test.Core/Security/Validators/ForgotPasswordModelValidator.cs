using FluentValidation;
using OutputCache_test.Core.Common.Validators;
using OutputCache_test.Core.Security.Dtos;

namespace OutputCache_test.Core.Security.Validators;

public sealed class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
{
    public ForgotPasswordModelValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email is required")
            .ValidateEmail();
    }
}
