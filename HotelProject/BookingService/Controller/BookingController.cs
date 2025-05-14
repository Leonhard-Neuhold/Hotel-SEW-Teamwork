using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controller;

[ApiController]
[Route("api/[controller]")]
public class BookingController(BookingManager bookingManager) : ControllerBase
{
    [HttpPost("MakeReservation")]
    public async Task<IActionResult> MakeReservation(int guestId, int roomId)
    {
        var booking = await bookingManager.MakeReservationAsync(guestId, roomId, DateTime.Today);
        if (booking == null)
        {
            return BadRequest("Zimmer ist nicht verfügbar.");
        }
        return Ok(booking);
    }
}