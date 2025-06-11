using Microsoft.EntityFrameworkCore;
using RoomService.Context;
using RoomService.Interfaces;
using RoomService.Model;

namespace RoomService.Services;

public class RoomManager(RoomContext context, IBookingClient bookingClient)
{
    public async Task<Room?> GetRoomsAsync(int roomId)
    {
        return await context.Set<Room>().FindAsync(roomId);
    }
    
    public async Task<List<Room>> GetAvailableRoomsAsync(DateTime date)
    {
        var allRooms = await context.Rooms.Select(r => r).ToListAsync();
        var bookedRoomIds = await bookingClient.GetBookedRoomIdsAsync(date);

        var availableRooms = allRooms
            .Where(room => !bookedRoomIds.Contains(room.RoomId))
            .ToList();

        return availableRooms;
    }
}