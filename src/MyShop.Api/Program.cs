using MyShop.Infrastructure;
using MyShop.Application;
using Serilog;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, LoggerConfiguration) =>
{
    LoggerConfiguration.WriteTo
    .Console();
});

var app = builder.Build();
app.UseInfrastructure();
app.Run();
