using Xunit;

namespace MyShop.Tests.Integration.Controllers;

[Collection("api")]
public abstract class ControllerTests : IClassFixture<OptionsProvider>
{
    protected HttpClient HttpClient { get; }

    public ControllerTests()
    {
        var app = new MyShopTestApp();
        HttpClient = app.HttpClient;
    }
}
