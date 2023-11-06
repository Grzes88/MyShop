using Shouldly;
using Xunit;

namespace MyShop.Tests.Integration.Controllers;

public class HomeControllerTests : ControllerTests
{
    [Fact]
    public async Task get_base_endpoint_should_return_200_ok_status_code_and_api_name()
    {
        var response = await HttpClient.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();
        content.ShouldBe("MyShop API [test]");
    }
}
