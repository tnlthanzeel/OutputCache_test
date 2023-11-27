using OutputCache_test.Core.Common.Interfaces;
using OutputCache_test.Core.Security.Interfaces;
using OutputCache_test.Persistence.Repositories;
using OutputCache_test.Persistence.Repositories.Security;
using OutputCache_test.SharedKernal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace OutputCache_test.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString(AppConstants.Database.APIDbConnectionName))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.TryAddScoped<IUserSecurityRespository, UserSecurityRespository>();
        services.TryAddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
