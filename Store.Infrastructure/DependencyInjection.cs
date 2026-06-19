using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services)
    {
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddTransient<IProdutoRepository, ProdutoRepository>();

        return services;
    }
}