using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Abstractions;

namespace Store.Repositories;

public class ProdutoRepository (StoreContext context) : IProductRepository
{
    public async Task<List<Produto>?> GetAllAsync (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Produtos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Produto?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<Produto> CreateAsync (Produto produto, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(produto, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return produto;
    }

    public async Task<Produto> UpdateAsync (Produto produto, CancellationToken cancellationToken = default)
    {
        context.Update(produto);
        await context.SaveChangesAsync(cancellationToken);

        return produto;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var produto = await context.Produtos.FindAsync([id], cancellationToken: cancellationToken)
            ?? throw new KeyNotFoundException("Produto not found");

        context.Remove(produto);
        await context.SaveChangesAsync(cancellationToken);
    }
}