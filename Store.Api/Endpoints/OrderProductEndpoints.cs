using MediatR;
using Create = Store.Application.UseCases.OrderProduct.Create;
using Delete = Store.Application.UseCases.OrderProduct.Delete;
using GetByOrderId = Store.Application.UseCases.OrderProduct.GetByOrderId;
using Update = Store.Application.UseCases.OrderProduct.Update;

namespace Store.Api.Endpoints;

public static class OrderProductEndpoints
{
    public static void MapOrderProductEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders/{orderId:guid}/items");

        group.MapGet("", async (Guid orderId, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new GetByOrderId.Command(orderId), ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapPost("", async (Guid orderId, Create.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command with { OrderId = orderId }, ct);
            return result.IsSuccess
                ? Results.Created($"/orders/{orderId}/items/{result.Value.ProductId}", result.Value)
                : Results.BadRequest(result.Error);
        });

        group.MapPut("{productId:guid}", async (Guid orderId, Guid productId, Update.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command with { OrderId = orderId, ProductId = productId }, ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapDelete("{productId:guid}", async (Guid orderId, Guid productId, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new Delete.Command(orderId, productId), ct);
            return result.IsSuccess ? Results.NoContent() : Results.NotFound(result.Error);
        });
    }
}
