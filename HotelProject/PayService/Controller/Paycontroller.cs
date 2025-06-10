using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PayService.Controller
{
    [ApiController]
    [Route("PayManagement")]
    public class PayController : ControllerBase
    {
        private readonly ILogger<PayController> _logger;

        public PayController(ILogger<PayController> logger)
        {
            _logger = logger;
        }

        [HttpGet("pay")]
        public IActionResult ProcessPayment(int bookingId)
        {
            if (bookingId <= 0)
            {
                _logger.LogWarning("Ungültige Buchungs-ID: {BookingId}", bookingId);
                return BadRequest("Ungültige Buchungs-ID");
            }

            try
            {
                _logger.LogInformation("Zahlung für Buchung {BookingId} wird bearbeitet", bookingId);

                return Ok("Zahlung erfolgreich verarbeitet");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler bei der Zahlung für Buchung {BookingId}", bookingId);
                return StatusCode(500, "Interner Serverfehler");
            }
        }
    }
}