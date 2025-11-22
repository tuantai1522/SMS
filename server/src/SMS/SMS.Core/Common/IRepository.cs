namespace SMS.Core.Common;

/// <summary>
/// Repository Interface for any Entity
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : AggregateRoot
{
    /// <summary>
    /// Add item
    /// </summary>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Add items
    /// </summary>
    Task AddRangeAsync(IReadOnlyList<T> entites, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update item
    /// </summary>
    void UpdateAsync(T entity);

    /// <summary>
    /// Delete item
    /// </summary>
    void DeleteAsync(T entity);
}