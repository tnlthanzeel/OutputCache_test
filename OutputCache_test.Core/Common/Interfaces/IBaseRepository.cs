﻿namespace OutputCache_test.Core.Common.Interfaces;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
