using BookingService;
using BookingService.Config;
using BookingService.Interfaces;
using BookingService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Generates metadata for API Explorer.
builder.Services.AddSwaggerGen();          // Registers Swagger generator service.

builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlite("Data Source=bookings.db"));

builder.Services.AddScoped<IRoomService, DummyRoomService>();
builder.Services.AddScoped<BookingManager>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Enable Swagger in the development environment.
{
    app.UseSwagger();                // Serve the Swagger JSON endpoint.
    app.UseSwaggerUI();              // Serve the Swagger UI for testing endpoints.
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();