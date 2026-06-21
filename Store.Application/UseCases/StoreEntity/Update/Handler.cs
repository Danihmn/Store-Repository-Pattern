using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.StoreEntity.Update;

public sealed class Handler (IStoreRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var store = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (store is null)
            return Result.Failure<Response>(new Error("404", "Store not found"));

        store.LegalName = request.LegalName;
        store.TradeName = request.TradeName;
        store.Cnpj = request.Cnpj;
        store.Active = request.Active;
        store.AddressId = request.AddressId;
        store.UpdatedAt = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(store, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            LegalName: updated.LegalName,
            TradeName: updated.TradeName,
            Cnpj: updated.Cnpj,
            Active: updated.Active,
            AddressId: updated.AddressId));
    }
}
