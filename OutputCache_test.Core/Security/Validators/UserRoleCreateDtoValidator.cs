using FluentValidation;
using OutputCache_test.Core.Security.Dtos;
using OutputCache_test.Core.Security.Interfaces;

namespace OutputCache_test.Core.Security.Validators;

public sealed class UserRoleCreateDtoValidator : AbstractValidator<UserRoleCreateDto>
{
    public UserRoleCreateDtoValidator(IUserSecurityRespository userSecurityRespository)
    {
        RuleFor(r => r.RoleName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Role is required")
            .MaximumLength(256).WithMessage("Role name must be less than 256 character")
            .MustAsync(async (roleName, cancellation) =>
            {
                bool doesRoleExist = await userSecurityRespository.DoesRoleExists(roleName, cancellation);
                return !doesRoleExist;
            }).WithMessage(w => $"Role name ({w.RoleName}) already exists");

    }
}
