using Ardalis.Specification;
using OutputCache_test.Core.Security.Entities;

namespace OutputCache_test.Core.Security.Specs;

internal sealed class SingleUserSpec : Specification<ApplicationUser>
{
    public SingleUserSpec()
    {
        Query.Include(i => i.UserProfile);
    }
}
