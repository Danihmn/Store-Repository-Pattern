using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Address.Update;

public sealed class Handler (IAddressRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var address = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
            return Result.Failure<Response>(new Error("404", "Address not found"));

        address.Street = request.Street;
        address.City = request.City;
        address.State = request.State;
        address.ZipCode = request.ZipCode;
        address.UpdatedAt = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(address, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            Street: updated.Street,
            City: updated.City,
            State: updated.State,
            ZipCode: updated.ZipCode));
    }
}
