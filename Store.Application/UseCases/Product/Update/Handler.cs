using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Product.Update;

public sealed class Handler (IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result.Failure<Response>(new Error("404", "Product not found"));

        product.UpdateProduct(request.Description, request.UnitPrice, request.Stock);

        var updated = await repository.UpdateAsync(product, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            Description: updated.Description,
            UnitPrice: updated.UnitPrice,
            Stock: updated.Stock));
    }
}
