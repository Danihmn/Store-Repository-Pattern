using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.ProdutoPedido.Delete;

public sealed class Handler (IProdutoPedidoRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = await repository.GetByCompositeKeyAsync(request.PedidoId, request.ProdutoId, cancellationToken);

        if (item is null)
            return Result.Failure(new Error("404", "Item do pedido não encontrado"));

        await repository.DeleteByCompositeKeyAsync(request.PedidoId, request.ProdutoId, cancellationToken);

        return Result.Success();
    }
}
