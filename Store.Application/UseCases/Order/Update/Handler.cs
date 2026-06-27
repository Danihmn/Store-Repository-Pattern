using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Order.Update;

public sealed class Handler (IOrderRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
            return Result.Failure<Response>(new Error("404", "Order not found"));

        order.UpdateOrder(request.Status, request.Total);

        var updated = await repository.UpdateAsync(order, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            Status: updated.Status.Value.ToString(),
            Total: updated.Total.Value,
            CustomerId: updated.CustomerId,
            AddressId: updated.AddressId));
    }
}
