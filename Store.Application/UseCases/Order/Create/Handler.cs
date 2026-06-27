using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Order.Create;

public sealed class Handler (IOrderRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var order = new Store.Domain.Entities.Order("pending", request.Total, request.CustomerId, request.AddressId);

        var created = await repository.CreateAsync(order, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Status: created.Status.Value.ToString(),
            Total: created.Total.Value,
            CustomerId: created.CustomerId,
            AddressId: created.AddressId));
    }
}
