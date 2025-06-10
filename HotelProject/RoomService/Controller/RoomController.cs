using Microsoft.AspNetCore.Mvc;
using RoomService.Model;

namespace RoomService.Controller;

[ApiController]
[Route("api/[controller]")]
public class RoomController
{
    [HttpGet("GetAvailableRooms")]
    public IActionResult GetAvailableRooms()
    {
        throw new NotImplementedException("Wird no gmocht!!");
    }
}