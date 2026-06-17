using Store.Models;
using Store.Repositories.Abstractions;

namespace Store.Api.Endpoints;

public static class Endpoints
{
    public static WebApplication MapEndpoints (this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/produtos");

        group.MapGet("/", async (IProductRepository repository)
            => Results.Ok(await repository.GetAllAsync(skip: 0, take: 30)));

        group.MapGet("/{id}", async (IProductRepository repository, Guid id)
            => Results.Ok(await repository.GetByIdAsync(id)));

        group.MapPost("/", async (IProductRepository repository, Produto produto)
            => Results.Ok(await repository.CreateAsync(produto)));

        group.MapPut("/", async (IProductRepository repository, Produto produto)
            => Results.Ok(await repository.UpdateAsync(produto)));

        group.MapDelete("/{id}", async (IProductRepository repository, Guid id) =>
        {
            try
            {
                await repository.DeleteAsync(id);
                return Results.NoContent();
            }
            catch (KeyNotFoundException)
            {
                return Results.NotFound();
            }
        });

        return app;
    }
}

