using Soenneker.Wise.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Wise.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Wise API client backed by the configured HTTP transport.
/// </summary>
public interface IWiseOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Wise API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Wise API client.</returns>
    ValueTask<WiseOpenApiClient> Get(CancellationToken cancellationToken = default);
}
