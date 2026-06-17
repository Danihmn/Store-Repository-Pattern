using Store.Api.Endpoints;
using Store.Configurations;
using Store.Repositories;
using Store.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddTransient<IProductRepository, ProdutoRepository>();

var app = builder.Build();

app.MapEndpoints();
app.Run();
