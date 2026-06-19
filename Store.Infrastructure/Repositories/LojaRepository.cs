using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class LojaRepository (StoreContext context) : ILojaRepository
{
    public async Task<IEnumerable<Loja>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Lojas
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Loja?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Lojas
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

    public async Task<Loja> CreateAsync (Loja entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Loja> UpdateAsync (Loja entity, CancellationToken cancellationToken = default)
    {
        context.Lojas.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var loja = await context.Lojas.FirstOrDefaultAsync(l => l.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException("Loja not found");

        context.Lojas.Remove(loja);
        await context.SaveChangesAsync(cancellationToken);
    }
}
