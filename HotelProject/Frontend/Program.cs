using Frontend.Components;
using Frontend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
        options.MapInboundClaims = false;
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
        options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
        options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
        options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scopes:0"] ?? string.Empty);
        options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scopes:1"] ?? string.Empty);
        options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scopes:2"] ?? string.Empty);
        options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scopes:3"] ?? string.Empty);

        options.ResponseType = "code";
        options.UsePkce = true;
        options.ResponseMode = "query";
        options.SaveTokens = true;
        options.MapInboundClaims = false;
        options.GetClaimsFromUserInfoEndpoint = true;
    });

// HttpClients
builder.Services
    .AddHttpClient("ApiClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7016");
    });
builder.Services
    .AddHttpClient("RestaurantClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7243");
    });
builder.Services
    .AddHttpClient("BookingClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7187");
    });
builder.Services
    .AddHttpClient("RoomClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7126");
    });
builder.Services
    .AddHttpClient("FeedbackClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7156");
    });
builder.Services
    .AddHttpClient("PayClient", client =>
    {
        client.BaseAddress = new Uri("http://localhost:5292");
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ApiService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/authentication/login", async (HttpContext context) =>
{
    Console.WriteLine("Called Endpoint!");
    var returnUrl = context.Request.Query["returnUrl"];
    if (string.IsNullOrWhiteSpace(returnUrl))
    {
        returnUrl = "/";
    }

    await context.ChallengeAsync("oidc", new AuthenticationProperties
    {
        RedirectUri = returnUrl
    });
});

app.MapGet("/authentication/logout", async (HttpContext context) =>
{
    await context.SignOutAsync("Cookies");
    await context.SignOutAsync("oidc", new AuthenticationProperties
    {
        RedirectUri = "/"
    });
});

app.Run();

public class IdentityServerSettings
{
    public string DiscoveryUrl { get; set; }
    public string ClientName { get; set; }
    public string ClientPassword { get; set; }
    public bool UseHttps { get; set; }
}