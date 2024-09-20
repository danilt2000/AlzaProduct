using AlzaProduct.Core.Interfaces.Product;
using AlzaProduct.Persistent.EF.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaProduct.Persistent.EF;
public static class ServiceBindings
{
    public static IServiceCollection AddEFPersistence(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        serviceCollection.AddScoped<AppDbContext>();

        return serviceCollection;
    }
}
