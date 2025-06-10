using System.ComponentModel.DataAnnotations;

namespace KundenfeedbackService.Models;

public class CustomerFeedback
{
    [Key]
    public int FeedbackId { get; set; }

    [Required]
    public string? GuestId { get; set; }

    [Required]
    public string Complaint { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; } = DateTime.Now;
}