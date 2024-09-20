using AlzaProduct.Core.Interfaces.Persistent;
using AlzaProduct.Persistent.EF.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaProduct.Persistent.EF;
public static class ServiceBindings
{
    public static IServiceCollection AddEFPersistence(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<AppDbContext>();

        return serviceCollection;
    }
}
