using BookingService.Interfaces;

namespace BookingService;

public class DummyRoomService : IRoomService
{
    public bool IsRoomAvailable(int roomId, DateTime date)
    {
        return true;
    }
}