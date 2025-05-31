using Scalar.AspNetCore;
using AnimalService.Infrastructure.Extensions;
using AnimalService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimalDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "AnimalService API";
    });
}

app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

app.MapControllers();

app.Run();
