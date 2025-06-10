using Microsoft.EntityFrameworkCore;
using RoomService.Model;

namespace RoomService.Context;

public class RoomContext(DbContextOptions<RoomContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
}