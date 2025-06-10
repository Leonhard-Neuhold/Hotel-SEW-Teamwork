namespace RoomService.Interfaces;

public interface IBookingClient
{
    Task<List<int>> GetBookedRoomIdsAsync(DateTime date);
}
