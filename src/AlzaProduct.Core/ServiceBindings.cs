using Microsoft.Extensions.DependencyInjection;

namespace AlzaProduct.Core;

public static class ServiceBindings
{
    public static IServiceCollection AddCore(
        this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
