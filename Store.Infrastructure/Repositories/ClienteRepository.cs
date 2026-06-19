using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infrastructure.Data.StoreContext;

namespace Store.Infrastructure.Repositories;

internal class ClienteRepository (StoreContext context) : IClienteRepository
{
    public async Task<IEnumerable<Cliente>?> GetAllAsync
        (int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        => await context.Clientes
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Cliente?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
        => await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(cliente => cliente.Id == id, cancellationToken);

    public async Task<Cliente> CreateAsync (Cliente entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<Cliente> UpdateAsync (Cliente entity, CancellationToken cancellationToken = default)
    {
        var cliente = context.Clientes.FirstOrDefault(cliente => cliente.Id == entity.Id)
            ?? throw new KeyNotFoundException("Cliente not found");

        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync (Guid id, CancellationToken cancellationToken = default)
    {
        var cliente = context.Clientes.FirstOrDefault(cliente => cliente.Id == id)
            ?? throw new KeyNotFoundException("Cliente not found");

        context.Clientes.Remove(cliente);
        await context.SaveChangesAsync(cancellationToken);
    }
}