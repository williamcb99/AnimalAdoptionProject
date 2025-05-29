using AnimalService.Application.Interfaces;
using Scalar.AspNetCore;
using AnimalService.Infrastructure.Persistence;
using AnimalService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AnimalDbContext>(options =>
    options.UseInMemoryDatabase("AnimalDb"));

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimalDbContext>();
    context.Database.EnsureCreated();
}

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Welcome to the Animal Service API!");

app.Run();


