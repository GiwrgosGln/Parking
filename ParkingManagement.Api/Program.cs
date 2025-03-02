using Microsoft.Extensions.DependencyInjection;
using ParkingManagement.Application;
using ParkingManagement.Application.Database;
using ParkingManagement.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
