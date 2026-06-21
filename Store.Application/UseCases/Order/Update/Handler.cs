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

        order.Status = request.Status;
        order.Total = request.Total;
        order.CustomerId = request.CustomerId;
        order.AddressId = request.AddressId;
        order.UpdatedAt = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(order, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            Status: updated.Status,
            Total: updated.Total,
            CustomerId: updated.CustomerId,
            AddressId: updated.AddressId));
    }
}
