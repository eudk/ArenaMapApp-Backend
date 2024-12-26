using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly MenuService _menuService;

    public MenuController(MenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("type/{stallType}")]
    public IActionResult GetMenuItemsByType(string stallType)
    {
        var menuItems = _menuService.GetMenuItemsByType(stallType);
        return Ok(menuItems);
    }

    [HttpPost]
    public async Task<IActionResult> AddMenuItem([FromBody] MenuItem menuItem)
    {
        if (string.IsNullOrEmpty(menuItem.ImageBase64))
        {
            return BadRequest(new { Message = "Image is required" });
        }

        var createdItem = await _menuService.AddMenuItem(menuItem);
        return CreatedAtAction(nameof(GetMenuItemsByType),
            new { stallType = createdItem.StallType }, createdItem);
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