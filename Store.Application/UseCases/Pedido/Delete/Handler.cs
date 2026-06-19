using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Pedido.Delete;

public sealed class Handler (IPedidoRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var pedido = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (pedido is null)
            return Result.Failure(new Error("404", "Pedido não encontrado"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
