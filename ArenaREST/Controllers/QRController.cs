using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QRController : ControllerBase
    {
        private readonly QRService _qrService;

        public QRController(QRService qrService)
        {
            _qrService = qrService;
        }

        [HttpPost("generate/{orderId}")]
        public async Task<IActionResult> GenerateQRCodeForOrder(int orderId)
        {
            try
            {
                var qrCodeBase64 = await _qrService.GenerateQRCodeForOrder(orderId);
                return Ok(new { QRCode = qrCodeBase64 });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetQRCodeByOrderId(int orderId)
        {
            var qrCode = await _qrService.GetQRCodeByOrderId(orderId);
            if (qrCode == null)
            {
                return NotFound(new { Message = "QR Code not found for this order" });
            }

            return Ok(new { QRCode = qrCode });
        }
    }
}
