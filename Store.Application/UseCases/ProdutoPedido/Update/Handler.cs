using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.ProdutoPedido.Update;

public sealed class Handler (IProdutoPedidoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = await repository.GetByCompositeKeyAsync(request.PedidoId, request.ProdutoId, cancellationToken);

        if (item is null)
            return Result.Failure<Response>(new Error("404", "Item do pedido não encontrado"));

        item.Quantidade = request.Quantidade;

        var updated = await repository.UpdateAsync(item, cancellationToken);

        return Result.Success(new Response(
            PedidoId: updated.PedidoId,
            ProdutoId: updated.ProdutoId,
            Quantidade: updated.Quantidade));
    }
}
