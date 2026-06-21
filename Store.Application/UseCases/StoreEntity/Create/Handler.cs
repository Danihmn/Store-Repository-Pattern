using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.StoreEntity.Create;

public sealed class Handler (IStoreRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var store = new Store.Domain.Entities.Store
        {
            LegalName = request.LegalName,
            TradeName = request.TradeName,
            Cnpj = request.Cnpj,
            Active = request.Active,
            AddressId = request.AddressId,
            CreatedAt = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(store, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            LegalName: created.LegalName,
            TradeName: created.TradeName,
            Cnpj: created.Cnpj,
            Active: created.Active,
            AddressId: created.AddressId));
    }
}
