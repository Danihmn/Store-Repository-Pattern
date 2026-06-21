using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.OrderProduct.Update;

public sealed class Handler (IOrderProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = await repository.GetByCompositeKeyAsync(request.OrderId, request.ProductId, cancellationToken);

        if (item is null)
            return Result.Failure<Response>(new Error("404", "Order product not found"));

        item.Quantity = request.Quantity;

        var updated = await repository.UpdateAsync(item, cancellationToken);

        return Result.Success(new Response(
            OrderId: updated.OrderId,
            ProductId: updated.ProductId,
            Quantity: updated.Quantity));
    }
}
