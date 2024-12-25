using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaREST.Repositories
{
    public class MenuRepository
    {
        private readonly ArenaDbContext _context;

        public MenuRepository(ArenaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItem> GetMenuItemsForEvent(int eventId)
        {
            return _context.MenuItems 
                .Where(menuItem => menuItem.EventID == eventId)
                .ToList();
        }

        public async Task<MenuItem> AddMenuItem(MenuItem menuItem)
        {
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
}
