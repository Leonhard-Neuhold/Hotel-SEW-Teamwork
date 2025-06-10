using Microsoft.AspNetCore.Mvc;
using KundenFeedbackService.Services;
using Microsoft.AspNetCore.Authorization;

namespace KundenFeedbackService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerServiceController(CustomerFeedbackService feedbackService) : ControllerBase
    {
        [HttpPost("SubmitComplaint")]
        [Authorize]
        public async Task<IActionResult> SubmitComplaint([FromBody] FeedbackDto feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback.complaint))
                return BadRequest("Complaint cannot be empty.");

            var result = await feedbackService.SubmitComplaintAsync(feedback.guestId, feedback.complaint);
            return Ok(result);
        }

        [HttpGet("AllFeedbacks")]
        [Authorize]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }
    }
}

public record FeedbackDto(string guestId, string complaint);