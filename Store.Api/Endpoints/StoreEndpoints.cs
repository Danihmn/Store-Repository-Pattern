using MediatR;
using Create = Store.Application.UseCases.StoreEntity.Create;
using Delete = Store.Application.UseCases.StoreEntity.Delete;
using GetAll = Store.Application.UseCases.StoreEntity.GetAll;
using GetById = Store.Application.UseCases.StoreEntity.GetById;
using Update = Store.Application.UseCases.StoreEntity.Update;

namespace Store.Api.Endpoints;

public static class StoreEndpoints
{
    public static void MapStoreEndpoints (this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/stores").WithTags("Stores");

        group.MapGet("", async (ISender sender, CancellationToken cancellationToken, int skip = 0, int take = 10) =>
        {
            var result = await sender.Send(new GetAll.Command(skip, take), cancellationToken);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result);
        });

        group.MapGet("{id:Guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetById.Command(id), cancellationToken);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result);
        });

        group.MapPost("", async (Create.Command command, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command, cancellationToken);
            return result.IsSuccess
                ? Results.Created($"/stores/{result.Value.Id}", result.Value)
                : Results.BadRequest(result);
        });

        group.MapPut("{id:Guid}", async
            (Guid id, Update.Command command, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command with { Id = id }, cancellationToken);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(result);
        });

        group.MapDelete("{id:Guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new Delete.Command(id), cancellationToken);
            return result.IsSuccess ? Results.NoContent() : Results.NotFound(result);
        });
    }
}