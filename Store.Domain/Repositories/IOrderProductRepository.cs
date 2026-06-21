using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IOrderProductRepository : IRepository<OrderProduct>
{
    Task<IEnumerable<OrderProduct>?> GetByOrderIdAsync (Guid orderId, CancellationToken cancellationToken = default);
    Task<OrderProduct?> GetByCompositeKeyAsync (Guid orderId, Guid productId, CancellationToken cancellationToken = default);
    Task DeleteByCompositeKeyAsync (Guid orderId, Guid productId, CancellationToken cancellationToken = default);
}
