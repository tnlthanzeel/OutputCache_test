﻿namespace OutputCache_test.Core.Security.Dtos;

public record UserDto(Guid Id,
    string Email,
    string UserName,
    string FirstName,
    string LastName,
    string TimeZone,
    IReadOnlyList<UserClaimsDto> Claims,
    IReadOnlyList<string> Roles
    );
