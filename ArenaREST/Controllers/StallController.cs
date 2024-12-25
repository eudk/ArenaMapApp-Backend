using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StallController : ControllerBase
    {
        private readonly StallService _stallService;

        public StallController(StallService stallService)
        {
            _stallService = stallService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStalls()
        {
            var stalls = await _stallService.GetAllStalls();
            return Ok(stalls);
        }

        [HttpPost]
        public async Task<IActionResult> AddStall([FromBody] Stall stall)
        {
            var newStall = await _stallService.AddStall(stall);
            return CreatedAtAction(nameof(GetAllStalls), new { id = newStall.StallId }, newStall);
        }


        [HttpPut("{stallId}")]
        public async Task<IActionResult> UpdateStall(int stallId, [FromBody] Stall updatedStall)
        {
            var updated = await _stallService.UpdateStall(stallId, updatedStall);
            if (updated == null)
            {
                return NotFound(new { Message = "Stall not found" });
            }

            return Ok(updated);
        }

        [HttpDelete("{stallId}")]
        public async Task<IActionResult> DeleteStall(int stallId)
        {
            var success = await _stallService.DeleteStall(stallId);
            if (!success)
            {
                return NotFound(new { Message = "Stall not found" });
            }

            return NoContent();
        }
    }
}
