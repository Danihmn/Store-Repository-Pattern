using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.StoreEntity.GetAll;

public sealed class Handler (IStoreRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var stores = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (stores is null || !stores.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "No stores found"));

        var responses = stores.Select(s => new Response(
            Id: s.Id,
            CreatedAt: s.CreatedAt,
            UpdatedAt: s.UpdatedAt,
            LegalName: s.LegalName,
            TradeName: s.TradeName,
            Cnpj: s.Cnpj,
            Active: s.Active,
            AddressId: s.AddressId));

        return Result.Success(responses);
    }
}
