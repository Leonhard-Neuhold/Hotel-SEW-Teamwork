using Microsoft.EntityFrameworkCore;
using RoomService.Model;

namespace RoomService.Context;

public class RoomContext : DbContext

{
    public RoomContext(DbContextOptions<RoomContext> options) : base(options) { }
    DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}