using AuthenticationService.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddOpenApi();
builder.Services
    .AddControllersWithViews();
builder.Services
    .AddDbContextFactory<AppDbContext>(options => options.UseSqlite("Data Source=./Data/AuthService.db"));
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services
    .AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseIdentityServer();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();