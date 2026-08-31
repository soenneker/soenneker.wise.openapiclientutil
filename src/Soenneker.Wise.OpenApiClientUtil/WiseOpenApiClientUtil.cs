using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Wise.HttpClients.Abstract;
using Soenneker.Wise.OpenApiClientUtil.Abstract;
using Soenneker.Wise.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Wise.OpenApiClientUtil;

public sealed class WiseOpenApiClientUtil : IWiseOpenApiClientUtil
{
    private readonly AsyncSingleton<WiseOpenApiClient> _client;

    public WiseOpenApiClientUtil(IWiseOpenApiHttpClient httpClientProvider)
    {
        _client = new AsyncSingleton<WiseOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientProvider.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress?.AbsoluteUri.TrimEnd('/') ??
                          throw new InvalidOperationException("The Wise HTTP client does not have a base address.")
            };

            return new WiseOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<WiseOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
