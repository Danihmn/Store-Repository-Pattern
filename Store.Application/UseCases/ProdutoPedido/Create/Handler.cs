using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.ProdutoPedido.Create;

public sealed class Handler (IProdutoPedidoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var item = new Domain.Entities.ProdutoPedido
        {
            PedidoId = request.PedidoId,
            ProdutoId = request.ProdutoId,
            Quantidade = request.Quantidade
        };

        var created = await repository.CreateAsync(item, cancellationToken);

        return Result.Success(new Response(
            PedidoId: created.PedidoId,
            ProdutoId: created.ProdutoId,
            Quantidade: created.Quantidade));
    }
}
