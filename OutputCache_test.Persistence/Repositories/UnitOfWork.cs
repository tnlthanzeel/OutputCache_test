using OutputCache_test.Core.Common.Interfaces;

namespace OutputCache_test.Persistence.Repositories;

internal sealed class UnitOfWork : BaseRepository, IUnitOfWork
{
    public UnitOfWork(AppDbContext dbContext) : base(dbContext) { }
}
