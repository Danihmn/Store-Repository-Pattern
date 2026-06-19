using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IProdutoPedidoRepository : IRepository<ProdutoPedido>
{
    Task<IEnumerable<ProdutoPedido>?> GetByPedidoIdAsync (Guid pedidoId, CancellationToken cancellationToken = default);
    Task<ProdutoPedido?> GetByCompositeKeyAsync (Guid pedidoId, Guid produtoId, CancellationToken cancellationToken = default);
    Task DeleteByCompositeKeyAsync (Guid pedidoId, Guid produtoId, CancellationToken cancellationToken = default);
}
