using Microsoft.AspNetCore.Authorization;

namespace OutputCache_test.Api.Policies;

public interface IAuthPolicyApplyer
{
    void Apply(AuthorizationOptions options);
}
