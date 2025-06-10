using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controller;

[ApiController]
[Route("api/[controller]")]
public class BookingController(BookingManager bookingManager) : ControllerBase
{
    [HttpPost("MakeReservation")]
    [Authorize]
    public async Task<IActionResult> MakeReservation([FromBody] BookingDto bookingDto)
    {
        var booking = await bookingManager.MakeReservationAsync(bookingDto.guestId, bookingDto.roomId, DateTime.Today);
        if (booking == null)
        {
            return BadRequest("Zimmer ist nicht verfügbar.");
        }
        return Ok(booking);
    }
    
    [HttpGet("GetBookingsByDate")]
    public async Task<IActionResult> GetBookingsByDate([FromQuery] DateTime date)
    {
        var bookings = await bookingManager.GetBookingsByDateAsync(date);
        var bookedRoomIds = bookings.Select(b => b.RoomId).ToList();
        return Ok(bookedRoomIds);
    }

}

public record BookingDto(string guestId, int roomId);