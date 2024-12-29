using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

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
        menuItem.StallType = menuItem.StallType.ToUpper(); 
        _context.MenuItems.Add(menuItem);
        await _context.SaveChangesAsync();
        return menuItem;
    }

    public async Task<bool> DeleteMenuItem(int menuItemId)
    {
        var dependentOrderItems = await _context.OrderItems
            .Where(oi => oi.MenuItemId == menuItemId)
            .ToListAsync();

        if (dependentOrderItems.Any())
        {
            _context.OrderItems.RemoveRange(dependentOrderItems);
            await _context.SaveChangesAsync();
        }

        var menuItem = await _context.MenuItems.FindAsync(menuItemId);
        if (menuItem == null) return false;

        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();

        return true;
    }



    public IEnumerable<MenuItem> GetAllMenuItems()
    {
        return _context.MenuItems.ToList();
    }

    public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }
}