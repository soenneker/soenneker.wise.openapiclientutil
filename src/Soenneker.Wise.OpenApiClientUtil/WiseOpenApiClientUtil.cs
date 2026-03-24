using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Wise.HttpClients.Abstract;
using Soenneker.Wise.OpenApiClientUtil.Abstract;
using Soenneker.Wise.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Wise.OpenApiClientUtil;

///<inheritdoc cref="IWiseOpenApiClientUtil"/>
public sealed class WiseOpenApiClientUtil : IWiseOpenApiClientUtil
{
    private readonly AsyncSingleton<WiseOpenApiClient> _client;

    public WiseOpenApiClientUtil(IWiseOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<WiseOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Wise:ApiKey");
            string authHeaderValueTemplate = configuration["Wise:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
