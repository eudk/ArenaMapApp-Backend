using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var eventObj = await _eventService.GetEventById(eventId);

            if (eventObj == null)
                return NotFound(new { Message = "Event not found" });

            return Ok(eventObj);
        }
    }
}
