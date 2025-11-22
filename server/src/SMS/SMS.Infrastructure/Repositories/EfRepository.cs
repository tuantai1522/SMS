using SMS.Core.Common;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class EfRepository<TEntity>(IApplicationDbContext context) : IRepository<TEntity> where TEntity : AggregateRoot
{
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IReadOnlyList<TEntity> entites, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().AddRangeAsync(entites, cancellationToken);

    public void UpdateAsync(TEntity entity)
        => context.Set<TEntity>().Update(entity);

    public void DeleteAsync(TEntity entity)
        => context.Set<TEntity>().Remove(entity);
}
