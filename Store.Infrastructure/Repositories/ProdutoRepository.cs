using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class ProdutoRepository (StoreContext context) : IProdutoRepository
{
    public async Task<IEnumerable<Produto>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Produtos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Produto?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<Produto> CreateAsync (Produto entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Produto> UpdateAsync (Produto entity, CancellationToken cancellationToken = default)
    {
        context.Produtos.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var produto = await context.Produtos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException("Produto not found");

        context.Produtos.Remove(produto);
        await context.SaveChangesAsync(cancellationToken);
    }
}
