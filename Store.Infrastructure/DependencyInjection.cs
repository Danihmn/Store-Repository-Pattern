using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IStoreRepository, StoreRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IOrderProductRepository, OrderProductRepository>();

        return services;
    }
}
