using MediatR;
using Create = Store.Application.UseCases.Address.Create;
using Delete = Store.Application.UseCases.Address.Delete;
using GetAll = Store.Application.UseCases.Address.GetAll;
using GetById = Store.Application.UseCases.Address.GetById;
using Update = Store.Application.UseCases.Address.Update;

namespace Store.Api.Endpoints;

public static class AddressEndpoints
{
    public static void MapAddressEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/addresses");

        group.MapGet("", async (ISender sender, CancellationToken ct, int skip = 0, int take = 10) =>
        {
            var result = await sender.Send(new GetAll.Command(skip, take), ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapGet("{id:guid}", async (Guid id, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new GetById.Command(id), ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapPost("", async (Create.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command, ct);
            return result.IsSuccess
                ? Results.Created($"/addresses/{result.Value.Id}", result.Value)
                : Results.BadRequest(result.Error);
        });

        group.MapPut("{id:guid}", async (Guid id, Update.Command command, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(command with { Id = id }, ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result.Error);
        });

        group.MapDelete("{id:guid}", async (Guid id, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new Delete.Command(id), ct);
            return result.IsSuccess ? Results.NoContent() : Results.NotFound(result.Error);
        });
    }
}
