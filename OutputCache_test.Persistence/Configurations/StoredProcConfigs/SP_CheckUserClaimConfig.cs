﻿using OutputCache_test.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutputCache_test.Persistence.Configurations.StoredProcConfigs;

public sealed class SP_CheckUserClaimConfig : IEntityTypeConfiguration<SP_CheckUserClaim>
{
    public void Configure(EntityTypeBuilder<SP_CheckUserClaim> builder)
    {
        builder.HasNoKey();
        builder.ToTable((string)null!);
    }
}
