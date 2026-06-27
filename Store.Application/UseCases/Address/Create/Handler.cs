using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Address.Create;

public sealed class Handler (IAddressRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var address = new Store.Domain.Entities.Address(request.Street, request.City, request.State, request.ZipCode);
        var created = await repository.CreateAsync(address, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Street: created.Street,
            City: created.City,
            State: created.State,
            ZipCode: created.ZipCode));
    }
}
