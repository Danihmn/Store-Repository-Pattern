using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Address.GetAll;

public sealed class Handler (IAddressRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var addresses = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (addresses is null || !addresses.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "No addresses found"));

        var responses = addresses.Select(a => new Response(
            Id: a.Id,
            CreatedAt: a.CreatedAt,
            UpdatedAt: a.UpdatedAt,
            Street: a.Street,
            City: a.City,
            State: a.State,
            ZipCode: a.ZipCode));

        return Result.Success(responses);
    }
}
