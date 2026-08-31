using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Wise.HttpClients.Registrars;
using Soenneker.Wise.OpenApiClientUtil.Abstract;

namespace Soenneker.Wise.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the cached Wise API client provider.
/// </summary>
public static class WiseOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Wise API client provider as a singleton service.
    /// </summary>
    public static IServiceCollection AddWiseOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWiseOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWiseOpenApiClientUtil, WiseOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Wise API client provider as a scoped service while retaining the singleton HTTP transport.
    /// </summary>
    public static IServiceCollection AddWiseOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWiseOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWiseOpenApiClientUtil, WiseOpenApiClientUtil>();

        return services;
    }
}
