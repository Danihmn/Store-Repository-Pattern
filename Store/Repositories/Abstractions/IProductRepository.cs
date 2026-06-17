using Store.Models;

namespace Store.Repositories.Abstractions;

public interface IProductRepository
{
    Task<List<Produto>?> GetAllAsync (int skip = 0, int take = 10, CancellationToken cancellationToken = default);
    Task<Produto?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    Task<Produto> CreateAsync (Produto produto, CancellationToken cancellationToken = default);
    Task<Produto> UpdateAsync (Produto produto, CancellationToken cancellationToken = default);
    Task DeleteAsync (Guid id, CancellationToken cancellationToken = default);
}