using OutputCache_test.Core.Security.Entities;

namespace OutputCache_test.Core.Security.Interfaces;

public interface ITokenBuilder
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user, CancellationToken token);
}
