using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.OrderProduct.Delete;

public sealed class Handler (IOrderProductRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = await repository.GetByCompositeKeyAsync(request.OrderId, request.ProductId, cancellationToken);

        if (item is null)
            return Result.Failure(new Error("404", "Order product not found"));

        await repository.DeleteByCompositeKeyAsync(request.OrderId, request.ProductId, cancellationToken);

        return Result.Success();
    }
}
