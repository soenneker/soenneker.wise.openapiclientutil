using Soenneker.Wise.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Wise.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class WiseOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IWiseOpenApiClientUtil _openapiclientutil;

    public WiseOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IWiseOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
