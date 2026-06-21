using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Address.GetById;

public sealed class Handler (IAddressRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var address = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
            return Result.Failure<Response>(new Error("404", "Address not found"));

        return Result.Success(new Response(
            Id: address.Id,
            CreatedAt: address.CreatedAt,
            UpdatedAt: address.UpdatedAt,
            Street: address.Street,
            City: address.City,
            State: address.State,
            ZipCode: address.ZipCode));
    }
}
