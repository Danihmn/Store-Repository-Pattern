using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Order.Delete;

public sealed class Handler (IOrderRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
            return Result.Failure(new Error("404", "Order not found"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
