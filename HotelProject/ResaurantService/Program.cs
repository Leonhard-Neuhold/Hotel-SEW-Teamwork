using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Generates metadata for API Explorer.
builder.Services.AddSwaggerGen();          // Registers Swagger generator service.
builder.Services.AddControllers();

builder.Services
    .AddAuthentication()
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("scope1", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope1", "scope1");
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7120")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Enable Swagger in the development environment.
{
    app.UseSwagger();                // Serve the Swagger JSON endpoint.
    app.UseSwaggerUI();              // Serve the Swagger UI for testing endpoints.
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app
    .MapPost("/order", async ([FromBody] OrderDto order) => 
    {
        Console.WriteLine($"Gast {order.guest} bekommt {order.meal}");
        await Task.Delay(1000);
        return Results.NoContent();
    })
    .RequireAuthorization();

app.Run();

public record OrderDto(string guest, string meal);