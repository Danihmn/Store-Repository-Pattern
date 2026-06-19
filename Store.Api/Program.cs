using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Store.Api.Endpoints;
using Store.Application;
using Store.Infrastructure;
using Store.Infrastructure.Data.StoreContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapProdutoEndpoints();
app.MapClienteEndpoints();
app.MapEnderecoEndpoints();
app.MapLojaEndpoints();
app.MapPedidoEndpoints();
app.MapProdutoPedidoEndpoints();

app.MapScalarApiReference("/scalar", options =>
{
    options
        .WithTitle("Store API")
        .WithOpenApiRoutePattern("/openapi/v1.json");
});

app.Run();
