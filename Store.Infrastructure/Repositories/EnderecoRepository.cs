using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class EnderecoRepository (StoreContext context) : IEnderecoRepository
{
    public async Task<IEnumerable<Endereco>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Enderecos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Endereco?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Enderecos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task<Endereco> CreateAsync (Endereco entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Endereco> UpdateAsync (Endereco entity, CancellationToken cancellationToken = default)
    {
        context.Enderecos.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var endereco = await context.Enderecos.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException("Endereço not found");

        context.Enderecos.Remove(endereco);
        await context.SaveChangesAsync(cancellationToken);
    }
}
