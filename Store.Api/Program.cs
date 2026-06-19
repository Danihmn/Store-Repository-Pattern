using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application;
using Store.Infrastructure;
using Store.Infrastructure.Data.StoreContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/produtos/{id}", async
    (Guid id, ISender sender, CancellationToken cancellationToken) =>
{
    var command = new Store.Application.UseCases.Produto.GetById.Command(id);
    var result = await sender.Send(command, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.NotFound();
});

app.Run();
