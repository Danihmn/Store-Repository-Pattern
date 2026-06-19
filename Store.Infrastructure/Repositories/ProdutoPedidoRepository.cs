using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class ProdutoPedidoRepository (StoreContext context) : IProdutoPedidoRepository
{
    public async Task<IEnumerable<ProdutoPedido>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.ProdutosPedidos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<ProdutoPedido?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => throw new NotSupportedException("ProdutoPedido uses composite key. Use GetByCompositeKeyAsync.");

    public async Task<IEnumerable<ProdutoPedido>?> GetByPedidoIdAsync
        (Guid pedidoId, CancellationToken cancellationToken = default)
        => await context.ProdutosPedidos
            .AsNoTracking()
            .Where(pp => pp.PedidoId == pedidoId)
            .ToListAsync(cancellationToken);

    public async Task<ProdutoPedido?> GetByCompositeKeyAsync
        (Guid pedidoId, Guid produtoId, CancellationToken cancellationToken = default)
        => await context.ProdutosPedidos
            .AsNoTracking()
            .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoId && pp.ProdutoId == produtoId, cancellationToken);

    public async Task<ProdutoPedido> CreateAsync (ProdutoPedido entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ProdutoPedido> UpdateAsync (ProdutoPedido entity, CancellationToken cancellationToken = default)
    {
        context.ProdutosPedidos.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
        => throw new NotSupportedException("ProdutoPedido uses composite key. Use DeleteByCompositeKeyAsync.");

    public async Task DeleteByCompositeKeyAsync
        (Guid pedidoId, Guid produtoId, CancellationToken cancellationToken = default)
    {
        var item = await context.ProdutosPedidos
            .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoId && pp.ProdutoId == produtoId, cancellationToken)
            ?? throw new KeyNotFoundException("Item do pedido not found");

        context.ProdutosPedidos.Remove(item);
        await context.SaveChangesAsync(cancellationToken);
    }
}
