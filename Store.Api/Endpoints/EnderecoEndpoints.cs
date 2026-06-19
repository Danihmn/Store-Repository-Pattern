using MediatR;
using Create = Store.Application.UseCases.Endereco.Create;
using Delete = Store.Application.UseCases.Endereco.Delete;
using GetAll = Store.Application.UseCases.Endereco.GetAll;
using GetById = Store.Application.UseCases.Endereco.GetById;
using Update = Store.Application.UseCases.Endereco.Update;

namespace Store.Api.Endpoints;

public static class EnderecoEndpoints
{
    public static void MapEnderecoEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/enderecos");

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
                ? Results.Created($"/enderecos/{result.Value.Id}", result.Value)
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
