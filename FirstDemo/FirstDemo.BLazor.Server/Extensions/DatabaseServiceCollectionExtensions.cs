namespace FirstDemo.BLazor.Server.Extensions;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NorthwindContext>(opzioni =>
        {
            opzioni.UseSqlServer(configuration.GetConnectionString("NorthwindConnection"));
        });

        services.AddScoped<DbContext, NorthwindContext>();

        services.AddScoped<IRepository<Product, int>,
            EFRepository<Product, int>>();
        services.AddScoped<IRepository<Customer, string>,
            EFRepository<Customer, string>>();
        services.AddScoped<IRepository<Order, int>,
            EFRepository<Order, int>>();

        return services;
    }
}
