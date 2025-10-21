var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Simple hello endpoint
app.MapGet("/hello", () => new { message = "Hello from .NET 9 Web API!", timestamp = DateTime.UtcNow })
    .WithName("GetHello")
    .WithOpenApi();

// Root endpoint
app.MapGet("/", () => new { message = "Welcome to .NET 9 Web API Sample!", endpoints = new[] { "/hello", "/swagger" } })
    .WithName("GetRoot")
    .WithOpenApi();

app.Run();
