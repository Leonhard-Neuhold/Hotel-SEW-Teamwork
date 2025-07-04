using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RoomService.Context;
using RoomService.Interfaces;
using RoomService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoomContext>(options =>
    options.UseSqlite("Data Source=room.db"));

builder.Services.AddScoped<RoomManager>();
builder.Services.AddHttpClient<IBookingClient, BookingClient>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();