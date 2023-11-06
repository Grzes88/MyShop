using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace MyShop.Tests.Integration;

internal sealed class MyShopTestApp : WebApplicationFactory<Program>
{
    public HttpClient HttpClient { get; }

    public MyShopTestApp(Action<IServiceCollection> services = null)
    {
        HttpClient = WithWebHostBuilder(builder =>
        {
            if (services is not null)
            {
                builder.ConfigureServices(services);
            }

            builder.UseEnvironment("test");
        }).CreateClient();
    }
}
