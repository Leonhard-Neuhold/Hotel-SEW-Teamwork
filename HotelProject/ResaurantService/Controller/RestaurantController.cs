using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResaurantService.Controller;

[ApiController]
public class RestaurantController : ControllerBase
{
    [HttpPost("OrderFood")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> OrderRoomService([FromBody] OrderDto order)
    {
        Console.WriteLine($"Gast {order.guest} bekommt {order.meal}");
        await Task.Delay(1000);
        return Ok();
    }
}