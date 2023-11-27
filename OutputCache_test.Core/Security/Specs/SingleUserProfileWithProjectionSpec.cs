using Ardalis.Specification;
using OutputCache_test.Core.Security.Dtos;
using OutputCache_test.Core.Security.Entities;

namespace OutputCache_test.Core.Security.Specs;

public sealed class SingleUserProfileWithProjectionSpec : Specification<ApplicationUser, UserProfileDto>
{
    public SingleUserProfileWithProjectionSpec(Guid userId)
    {
        Query.Where(u => u.Id == userId);

        Query.Select(s => new UserProfileDto()
        {
            Id = s.Id,
            Email = s.Email!,
            UserName = s.UserName!,
            FirstName = s.UserProfile.FirstName,
            LastName = s.UserProfile.LastName,
            TimeZone = s.UserProfile.TimeZone,
        });
    }
}
