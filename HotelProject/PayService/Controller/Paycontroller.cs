using Microsoft.AspNetCore.Mvc;

namespace PayService.Controller;

[ApiController]
[Route("PayManagement")]
public class PayController
{
    [HttpGet("pay")]
    public int ProcessPayment(int bookingId)
    {
        return StatusCodes.Status200OK;
    }
}