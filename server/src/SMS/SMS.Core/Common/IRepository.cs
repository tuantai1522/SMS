namespace SMS.Core.Common;

/// <summary>
/// Repository Interface for any Entity
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<TEntity> 
    where TEntity : AggregateRoot
{
    /// <summary>
    /// Add item
    /// </summary>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Add items
    /// </summary>
    Task AddRangeAsync(IReadOnlyList<TEntity> entites, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Find an entity by id
    /// </summary>
    Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Update item
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);
    
    /// <summary>
    /// Delete item
    /// </summary>
    void Delete(TEntity entity);
    
    /// <summary>
    /// To find all
    /// </summary>
    Task<IReadOnlyList<TEntity>> FindAllAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// To verify existed entity by Id
    /// </summary>
    Task<bool> VerifyExistedEntityByIdAsync(Guid id, CancellationToken cancellationToken);
}