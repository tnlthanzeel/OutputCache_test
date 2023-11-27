namespace OutputCache_test.Core.Security.Dtos;

public sealed record UpdateUserProfileDto
    (
    string FirstName,
    string LastName,
    string TimeZone
    );
