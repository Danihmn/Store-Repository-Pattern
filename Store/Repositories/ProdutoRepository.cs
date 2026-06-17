using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Repositories;

public class ProdutoRepository (StoreContext context)
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

    public async Task<Produto> DeleteAsync (Produto produto, CancellationToken cancellationToken = default)
    {
        context.Remove(produto);
        await context.SaveChangesAsync(cancellationToken);

        return produto;
    }
}