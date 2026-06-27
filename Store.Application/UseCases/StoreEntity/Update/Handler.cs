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

        store.UpdateStore(request.LegalName, request.TradeName, request.Cnpj, request.Active, request.AddressId);

        var updated = await repository.UpdateAsync(store, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            LegalName: updated.LegalName,
            TradeName: updated.TradeName,
            Cnpj: updated.Cnpj.Value,
            Active: updated.Active,
            AddressId: updated.AddressId));
    }
}
