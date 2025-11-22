using Microsoft.EntityFrameworkCore;
using SMS.Core.Common;
using SMS.UseCases.Abstractions.Data;

namespace SMS.Infrastructure.Repositories;

public sealed class EfRepository<TEntity>(IApplicationDbContext context) : IRepository<TEntity> 
    where TEntity : AggregateRoot
{
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IReadOnlyList<TEntity> entites, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().AddRangeAsync(entites, cancellationToken);

    public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Update(TEntity entity)
        => context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);

    public async Task<IReadOnlyList<TEntity>> FindAllAsync(CancellationToken cancellationToken)
        => await context.Set<TEntity>().ToListAsync(cancellationToken);

    public async Task<bool> VerifyExistedEntityByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Set<TEntity>().AnyAsync(x => x.Id == id, cancellationToken);
}
