using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class PedidoRepository (StoreContext context) : IPedidoRepository
{
    public async Task<IEnumerable<Pedido>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Pedidos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Pedido?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Pedidos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<Pedido> CreateAsync (Pedido entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Pedido> UpdateAsync (Pedido entity, CancellationToken cancellationToken = default)
    {
        context.Pedidos.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException("Pedido not found");

        context.Pedidos.Remove(pedido);
        await context.SaveChangesAsync(cancellationToken);
    }
}
