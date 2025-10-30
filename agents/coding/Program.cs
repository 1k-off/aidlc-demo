var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => Results.Text("Hello from .NET 8 web app!"));

app.Run();