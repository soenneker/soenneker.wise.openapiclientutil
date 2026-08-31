[![](https://img.shields.io/nuget/v/soenneker.wise.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.wise.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.wise.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.wise.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.wise.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.wise.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.wise.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.wise.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Wise.OpenApiClientUtil

Provides a cached `WiseOpenApiClient` using the configured Wise API version and bearer access token.

## Installation

```bash
dotnet add package Soenneker.Wise.OpenApiClientUtil
```

## Configuration

```json
{
  "Wise": {
    "AccessToken": "your-access-token",
    "ClientBaseUrl": "https://api.wise.com/2026Q3/"
  }
}
```

For sandbox calls, use `https://api.wise-sandbox.com/2026Q3/`. The package does not obtain or refresh OAuth tokens. `Wise:ApiKey` remains supported as a legacy alias for `AccessToken`.

## Registration and usage

```csharp
using Soenneker.Wise.OpenApiClient.Models;
using Soenneker.Wise.OpenApiClientUtil.Abstract;
using Soenneker.Wise.OpenApiClientUtil.Registrars;

services.AddWiseOpenApiClientUtilAsSingleton();

public sealed class WiseProfileService
{
    private readonly IWiseOpenApiClientUtil _clientProvider;

    public WiseProfileService(IWiseOpenApiClientUtil clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<IReadOnlyList<Profile>> List(
        CancellationToken cancellationToken)
    {
        var client = await _clientProvider.Get(cancellationToken);
        return await client.Profiles.GetAsync(
            cancellationToken: cancellationToken) ?? [];
    }
}
```

`AddWiseOpenApiClientUtilAsScoped()` creates one generated client per scope while continuing to use the singleton HTTP transport. Disposing the scoped provider does not remove that shared transport.
