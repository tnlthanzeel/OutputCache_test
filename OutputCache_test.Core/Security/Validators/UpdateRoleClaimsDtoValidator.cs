using FluentValidation;
using OutputCache_test.Core.Security.Dtos;

namespace OutputCache_test.Core.Security.Validators;

public sealed class UpdateRoleClaimsDtoValidator : AbstractValidator<UpdateRoleClaimsDto>
{
    public UpdateRoleClaimsDtoValidator()
    {
        RuleFor(r => r.Permissions)
                .AppPermissionValueValidation();
    }
}
