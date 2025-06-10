using RoomService.Interfaces;

namespace RoomService.Services;

public class BookingClient(HttpClient httpClient) : IBookingClient
{
    public async Task<List<int>> GetBookedRoomIdsAsync(DateTime date)
    {
        var formattedDate = date.ToString("yyyy-MM-dd");
        var response = await httpClient.GetAsync($"https://localhost:7187/api/booking/GetBookingsByDate?date={formattedDate}");

        response.EnsureSuccessStatusCode();

        var bookedRoomIds = await response.Content.ReadFromJsonAsync<List<int>>();
        return bookedRoomIds ?? new List<int>();
    }
}
