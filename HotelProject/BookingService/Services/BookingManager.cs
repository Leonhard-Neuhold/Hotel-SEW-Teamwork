using BookingService.Config;
using BookingService.Interfaces;
using BookingService.Models;

namespace BookingService.Services;

public class BookingManager(BookingContext context, IRoomService roomService)
{
    public async Task<Booking?> MakeReservationAsync(int guestId, int roomId, DateTime date)
    {
        if (!roomService.IsRoomAvailable(roomId, date))
            return null;

        var booking = new Booking
        {
            GuestId = guestId,
            RoomId = roomId,
            BookingDate = date,
            IsPaid = false
        };

        context.Bookings.Add(booking);
        await context.SaveChangesAsync();
        return booking;
    }

    public async Task<Booking?> GetBookingAsync(int bookingId)
    {
        return await context.Bookings.FindAsync(bookingId);
    }

    public async Task MarkAsPaidAsync(int bookingId)
    {
        var booking = await context.Bookings.FindAsync(bookingId);
        if (booking != null)
        {
            booking.IsPaid = true;
            await context.SaveChangesAsync();
        }
    }
}