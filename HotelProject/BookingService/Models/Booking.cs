using System.ComponentModel.DataAnnotations;

namespace BookingService.Models;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    public string? GuestId { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public DateTime BookingDate { get; set; }

    public bool IsPaid { get; set; }
}