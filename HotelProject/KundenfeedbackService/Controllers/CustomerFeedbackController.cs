using Microsoft.AspNetCore.Mvc;
using KundenFeedbackService.Services;

namespace KundenFeedbackService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerServiceController(CustomerFeedbackService feedbackService) : ControllerBase
    {
        [HttpPost("SubmitComplaint")]
        public async Task<IActionResult> SubmitComplaint(int guestId, [FromBody] string complaint)
        {
            if (string.IsNullOrWhiteSpace(complaint))
                return BadRequest("Complaint cannot be empty.");

            var result = await feedbackService.SubmitComplaintAsync(guestId, complaint);
            return Ok(result);
        }

        [HttpGet("AllFeedbacks")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }
    }
}