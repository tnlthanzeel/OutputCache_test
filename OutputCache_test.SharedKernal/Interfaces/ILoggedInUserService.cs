namespace OutputCache_test.SharedKernal.Interfaces;

public interface ILoggedInUserService
{
    string UserId { get; }

    string? UserEmail { get; }

    string? UserTimeZone { get; }

    string? UserRole { get; }

    bool IsAdminUser();
}
