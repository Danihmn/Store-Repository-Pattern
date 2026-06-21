using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Product.GetById;

public sealed class Handler (IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result.Failure<Response>(new Error(Code: "404", Message: "Product not found"));

        return Result.Success(new Response(
            Id: product.Id,
            CreatedAt: product.CreatedAt,
            UpdatedAt: product.UpdatedAt,
            Description: product.Description,
            UnitPrice: product.UnitPrice,
            Stock: product.Stock));
    }
}
