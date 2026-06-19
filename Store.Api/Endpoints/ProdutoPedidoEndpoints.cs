using MediatR;
using Create = Store.Application.UseCases.ProdutoPedido.Create;
using Delete = Store.Application.UseCases.ProdutoPedido.Delete;
using GetByPedidoId = Store.Application.UseCases.ProdutoPedido.GetByPedidoId;
using Update = Store.Application.UseCases.ProdutoPedido.Update;

namespace Store.Api.Endpoints;

public static class ProdutoPedidoEndpoints
{
    public static void MapProdutoPedidoEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/pedidos/{pedidoId:guid}/itens");

        group.MapGet("", async (Guid pedidoId, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new GetByPedidoId.Command(pedidoId), ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapPost("", async (Guid pedidoId, Create.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command with { PedidoId = pedidoId }, ct);
            return result.IsSuccess
                ? Results.Created($"/pedidos/{pedidoId}/itens/{result.Value.ProdutoId}", result.Value)
                : Results.BadRequest(result.Error);
        });

        group.MapPut("{produtoId:guid}", async (Guid pedidoId, Guid produtoId, Update.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command with { PedidoId = pedidoId, ProdutoId = produtoId }, ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapDelete("{produtoId:guid}", async (Guid pedidoId, Guid produtoId, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new Delete.Command(pedidoId, produtoId), ct);
            return result.IsSuccess ? Results.NoContent() : Results.NotFound(result.Error);
        });
    }
}
