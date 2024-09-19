using AlzaProduct.Core;
using AlzaProduct.Persistent.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaProduct.BindingsProvider;

public static class ServiceBindings
{
    public static IServiceCollection AddAlzaProduct(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCore()
            .AddEFPersistence(configuration);

        return services;
    }
}
