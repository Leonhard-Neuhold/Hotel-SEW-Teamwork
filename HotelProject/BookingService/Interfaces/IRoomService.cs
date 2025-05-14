namespace BookingService.Interfaces;

public interface IRoomService
{
    bool IsRoomAvailable(int roomId, DateTime date);
}