using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyShop.Web;
using MyShop.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var apiUri = new Uri(builder.Configuration["ApiUrl"]!);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddHttpClient<ICategoryService, CategoryService>(ConfigureClient);
builder.Services.AddHttpClient<IProductService, ProductService>(ConfigureClient);
builder.Services.AddScoped<HttpResponseMessage>();

await builder.Build().RunAsync();

void ConfigureClient(HttpClient client)
    => client.BaseAddress = apiUri;
return;