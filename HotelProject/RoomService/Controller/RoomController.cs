using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomService.Services;

namespace RoomService.Controller;

[ApiController]
[Route("api/[controller]")]
public class RoomController(RoomManager roomManager) : ControllerBase
{
    [HttpGet("GetAvailableRooms")]
    [Authorize]
    public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime date)
    {
        var rooms = await roomManager.GetAvailableRoomsAsync(date);
        return Ok(rooms);
    }
}