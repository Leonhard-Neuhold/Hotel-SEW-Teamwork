using RoomService.Context;
using RoomService.Model;

namespace RoomService.Services;

public class RoomManager(RoomContext context)
{
    public async Task<Room?> GetRoomsAsync(int roomId)
    {
        return await context.Set<Room>().FindAsync(roomId);
    }
    
    public async Task<List<Room>> GetAvailableRoomsAsync(DateTime date)
    {
        throw new NotImplementedException("Wird no gmocht!!");
    }
}