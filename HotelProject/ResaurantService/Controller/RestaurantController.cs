using Microsoft.AspNetCore.Mvc;

namespace ResaurantService.Controller;

[ApiController]
public class RestaurantController : ControllerBase
{
    [HttpPost("OrderFood")]
    public async Task<IActionResult> OrderRoomService(int guestId, string meal)
    {
        Console.WriteLine($"Gast {guestId} bekommt {meal}");
        await Task.Delay(1000);
        return Ok();
    }
}