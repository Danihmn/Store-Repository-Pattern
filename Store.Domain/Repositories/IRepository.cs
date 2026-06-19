namespace Store.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>?> GetAllAsync (int skip = 0, int take = 10, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    Task<T> CreateAsync (T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync (T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync (Guid id, CancellationToken cancellationToken = default);
}