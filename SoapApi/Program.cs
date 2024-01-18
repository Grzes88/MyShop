using SoapCore;
using static SoapApi.CategoryServiceContract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSoapEndpoint<ICategoryService>("/CategoryService", new SoapEncoderOptions());
app.UseAuthorization();
app.MapControllers();
app.Run();