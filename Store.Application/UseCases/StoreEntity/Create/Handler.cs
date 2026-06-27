using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.StoreEntity.Create;

public sealed class Handler (IStoreRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var store = new Store.Domain.Entities.Store(
            request.LegalName,
            request.Cnpj,
            request.AddressId,
            request.TradeName,
            request.Active);


        var created = await repository.CreateAsync(store, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            LegalName: created.LegalName,
            TradeName: created.TradeName,
            Cnpj: created.Cnpj.Value,
            Active: created.Active,
            AddressId: created.AddressId));
    }
}
