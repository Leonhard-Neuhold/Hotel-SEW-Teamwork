using KundenfeedbackService.Models;
using Microsoft.EntityFrameworkCore;

namespace KundenfeedbackService.Config
{
    public class FeedbackContext(DbContextOptions<FeedbackContext> options) : DbContext(options)
    {
        public DbSet<CustomerFeedback> Feedbacks { get; set; }
    }
}