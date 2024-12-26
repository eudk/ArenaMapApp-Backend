using ArenaREST.Context;
using ArenaREST.Models;

public class MenuRepository
{
    private readonly ArenaDbContext _context;

    public MenuRepository(ArenaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<MenuItem> GetMenuItemsByType(string stallType)
    {
        return _context.MenuItems
            .Where(menuItem => menuItem.StallType.ToUpper() == stallType.ToUpper())
            .ToList();
    }

    public async Task<MenuItem> AddMenuItem(MenuItem menuItem)
    {
        menuItem.StallType = menuItem.StallType.ToUpper(); // Ensure consistent casing
        _context.MenuItems.Add(menuItem);
        await _context.SaveChangesAsync();
        return menuItem;
    }

    public async Task<bool> DeleteMenuItem(int itemId)
    {
        var menuItem = await _context.MenuItems.FindAsync(itemId);
        if (menuItem == null)
        {
            return false;
        }

        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
        return true;
    }
}