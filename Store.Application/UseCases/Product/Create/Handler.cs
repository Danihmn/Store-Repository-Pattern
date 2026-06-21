using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Product.Create;

public sealed class Handler (IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var product = new Store.Domain.Entities.Product
        {
            Description = request.Description,
            UnitPrice = request.UnitPrice,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(product, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Description: created.Description,
            UnitPrice: created.UnitPrice,
            Stock: created.Stock));
    }
}
