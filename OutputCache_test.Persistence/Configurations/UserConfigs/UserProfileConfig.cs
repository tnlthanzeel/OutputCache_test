using OutputCache_test.Core.Security.Entities;
using OutputCache_test.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutputCache_test.Persistence.Configurations.UserConfigs;

internal sealed class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasQueryFilter(w => w.IsDeleted == false);

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(AppConstants.StringLengths.FirstName);

        builder.Property(p => p.LastName).IsRequired().HasMaxLength(AppConstants.StringLengths.LastName);

        builder.Property(p => p.TimeZone).HasMaxLength(200).IsRequired();

        builder.HasData(new UserProfile()
        {
            Id = AppConstants.SuperAdmin.SuperUserId,
            FirstName = "Super",
            LastName = "Admin",
            TimeZone = "Sri Lanka Standard Time",
            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 30)),
        });
    }
}
