﻿using OutputCache_test.SharedKernal.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace OutputCache_test.Core.Security.Entities;

public sealed class Role : IdentityRole<Guid>, IAggregateRoot
{
    public Role() { }

    public Role(string roleName) : base(roleName) { }

    public bool IsDefault { get; set; } = false;
}

