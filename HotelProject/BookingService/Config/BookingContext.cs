using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Config;

public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }

    public DbSet<Booking> Bookings { get; set; }
}