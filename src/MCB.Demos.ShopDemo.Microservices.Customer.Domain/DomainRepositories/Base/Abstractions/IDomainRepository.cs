﻿using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Base.Abstractions
{
    public interface IDomainRepository<TAggregationRoot>
        where TAggregationRoot : IAggregationRoot
    {
        Task<bool> AddAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken);
        Task<bool> AddOrUpdateAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken);
        Task<(bool success, int removeCount)> RemoveAsync(Func<TAggregationRoot, bool> expression, CancellationToken cancellationToken);
        Task<(bool success, int removeCount)> RemoveAllAsync(CancellationToken cancellationToken);
        Task<TAggregationRoot> GetAsync(Guid tenantId, Guid id, CancellationToken cancellationToken);
        IAsyncEnumerable<TAggregationRoot> GetAsync(Func<TAggregationRoot, bool> expression, CancellationToken cancellationToken);
        IAsyncEnumerable<TAggregationRoot> GetAllAsync(Guid tenantId, Guid id, CancellationToken cancellationToken);
    }
}