using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Order.Create;

public sealed class Handler (IOrderRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var order = new Store.Domain.Entities.Order
        {
            Status = "pendente",
            Total = request.Total,
            CustomerId = request.CustomerId,
            AddressId = request.AddressId,
            CreatedAt = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(order, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Status: created.Status,
            Total: created.Total,
            CustomerId: created.CustomerId,
            AddressId: created.AddressId));
    }
}
