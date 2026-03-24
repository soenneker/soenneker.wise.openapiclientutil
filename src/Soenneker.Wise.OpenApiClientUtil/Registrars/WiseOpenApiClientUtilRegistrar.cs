using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Wise.HttpClients.Registrars;
using Soenneker.Wise.OpenApiClientUtil.Abstract;

namespace Soenneker.Wise.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class WiseOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="WiseOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddWiseOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWiseOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWiseOpenApiClientUtil, WiseOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WiseOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddWiseOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWiseOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWiseOpenApiClientUtil, WiseOpenApiClientUtil>();

        return services;
    }
}
