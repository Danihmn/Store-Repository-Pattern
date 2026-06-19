using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.ProdutoPedido.GetByPedidoId;

public sealed class Handler (IProdutoPedidoRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var items = await repository.GetByPedidoIdAsync(request.PedidoId, cancellationToken);

        if (items is null || !items.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhum item encontrado para este pedido"));

        var responses = items.Select(i => new Response(
            PedidoId: i.PedidoId,
            ProdutoId: i.ProdutoId,
            Quantidade: i.Quantidade));

        return Result.Success(responses);
    }
}
