using Soenneker.Wise.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Wise.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WiseOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IWiseOpenApiClientUtil _openapiclientutil;

    public WiseOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IWiseOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
