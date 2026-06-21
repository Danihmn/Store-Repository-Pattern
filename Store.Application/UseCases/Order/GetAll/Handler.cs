using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Order.GetAll;

public sealed class Handler (IOrderRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var orders = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (orders is null || !orders.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "No orders found"));

        var responses = orders.Select(o => new Response(
            Id: o.Id,
            CreatedAt: o.CreatedAt,
            UpdatedAt: o.UpdatedAt,
            Status: o.Status,
            Total: o.Total,
            CustomerId: o.CustomerId,
            AddressId: o.AddressId));

        return Result.Success(responses);
    }
}
