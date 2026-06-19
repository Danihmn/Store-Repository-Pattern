using MediatR;
using Create = Store.Application.UseCases.Cliente.Create;
using Delete = Store.Application.UseCases.Cliente.Delete;
using GetAll = Store.Application.UseCases.Cliente.GetAll;
using GetById = Store.Application.UseCases.Cliente.GetById;
using Update = Store.Application.UseCases.Cliente.Update;

namespace Store.Api.Endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/clientes");

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
                ? Results.Created($"/clientes/{result.Value.Id}", result.Value)
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
