using System.Net.Http.Headers;
using Frontend.Components.Pages;
using Microsoft.AspNetCore.Authentication;

namespace Frontend.Services;

public class ApiService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
{
    public async Task<Weather.WeatherForecast[]> GetWeatherForecastAsync()
    {
        var accessToken = await httpContextAccessor.HttpContext!.GetTokenAsync("access_token");

        var client = httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.GetAsync("/weatherforecast");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception($"API call failed: {response.StatusCode}\n{content}");
        }

        return await response.Content.ReadFromJsonAsync<Weather.WeatherForecast[]>() 
               ?? Array.Empty<Weather.WeatherForecast>();
    }
}