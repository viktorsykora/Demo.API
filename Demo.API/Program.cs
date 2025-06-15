using Demo.Application;
using Demo.Infrastructure;
using Demo.Infrastructure.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DatabaseSeedHelpers.Seed(context);
}

app.MapOpenApi("/openapi/openapi.json");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
