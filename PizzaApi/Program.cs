
// CSE325 - ASP.NET Core Pizza Web API
// Configures the application, dependency injection,
// controllers, and Swagger documentation.

using PizzaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register controller support.
builder.Services.AddControllers();

// Register PizzaService as a singleton.
// The same in-memory collection is shared across requests.
builder.Services.AddSingleton<PizzaService>();

// Enable API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger for testing the API.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Map controller routes.
app.MapControllers();

app.Run();
