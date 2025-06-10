using KundenfeedbackService.Config;
using KundenfeedbackService.Models;
using Microsoft.EntityFrameworkCore;

namespace KundenFeedbackService.Services
{
    public class CustomerFeedbackService(FeedbackContext context)
    {
        public async Task<CustomerFeedback> SubmitComplaintAsync(string guestId, string complaint)
        {
            var feedback = new CustomerFeedback
            {
                GuestId = guestId,
                Complaint = complaint
            };

            context.Feedbacks.Add(feedback);
            await context.SaveChangesAsync();
            return feedback;
        }

        public async Task<List<CustomerFeedback>> GetAllFeedbacksAsync()
        {
            return await context.Feedbacks.OrderByDescending(f => f.SubmittedAt).ToListAsync();
        }
    }
}