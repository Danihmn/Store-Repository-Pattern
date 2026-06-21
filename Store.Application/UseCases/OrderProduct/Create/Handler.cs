using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.OrderProduct.Create;

public sealed class Handler (IOrderProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = new Store.Domain.Entities.OrderProduct
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };

        var created = await repository.CreateAsync(item, cancellationToken);

        return Result.Success(new Response(
            OrderId: created.OrderId,
            ProductId: created.ProductId,
            Quantity: created.Quantity));
    }
}
