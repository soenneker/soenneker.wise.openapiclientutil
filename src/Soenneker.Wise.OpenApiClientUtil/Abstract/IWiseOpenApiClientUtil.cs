using Soenneker.Wise.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Wise.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IWiseOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<WiseOpenApiClient> Get(CancellationToken cancellationToken = default);
}
