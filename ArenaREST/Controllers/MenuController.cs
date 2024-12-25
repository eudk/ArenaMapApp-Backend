using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("event/{eventId}")]
        public IActionResult GetMenuItemsForEvent(int eventId)
        {
            var menuItems = _menuService.GetMenuItemsForEvent(eventId);
            return Ok(menuItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem([FromBody] MenuItem menuItem)
        {
            var createdItem = await _menuService.AddMenuItem(menuItem);
            return CreatedAtAction(nameof(GetMenuItemsForEvent), new { eventId = createdItem.EventID }, createdItem);
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteMenuItem(int itemId)
        {
            var result = await _menuService.DeleteMenuItem(itemId);
            if (!result)
            {
                return NotFound(new { Message = "Menu item not found" });
            }

            return NoContent();
        }
    }
}
