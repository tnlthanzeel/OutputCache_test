using AutoMapper;
using OutputCache_test.Core.Security.Dtos;
using OutputCache_test.Core.Security.Entities;

namespace OutputCache_test.Core.AutomapperProfiles;

public sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser, UserSummaryDto>()
            .ForMember(d => d.FirstName, s => s.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(d => d.LastName, s => s.MapFrom(src => src.UserProfile.LastName));
    }
}
