using FluentValidation;
using OutputCache_test.Core.Security.Interfaces;

namespace OutputCache_test.Core.Security.Validators;

public static class AppRoleValidator
{
    public static IRuleBuilderOptions<T, string> AppRoleValidation<T>(this IRuleBuilderInitial<T, string> rule, IUserSecurityRespository userSecurityRespository)
    {
        return rule
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Role is required")
            .MaximumLength(256).WithMessage("Role name must be less than 256 character")
            .MustAsync(async (roleName, cancellation) =>
            {
                bool doesRoleExist = await userSecurityRespository.DoesRoleExists(roleName, cancellation);
                return doesRoleExist;
            }).WithMessage("Invalid role name");
    }
}
