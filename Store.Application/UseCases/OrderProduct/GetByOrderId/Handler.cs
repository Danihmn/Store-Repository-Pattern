using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.OrderProduct.GetByOrderId;

public sealed class Handler (IOrderProductRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var items = await repository.GetByOrderIdAsync(request.OrderId, cancellationToken);

        if (items is null || !items.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "No items found for this order"));

        var responses = items.Select(i => new Response(
            OrderId: i.OrderId,
            ProductId: i.ProductId,
            Quantity: i.Quantity));

        return Result.Success(responses);
    }
}
