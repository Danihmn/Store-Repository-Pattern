using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Store.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration (this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<StoreContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
}