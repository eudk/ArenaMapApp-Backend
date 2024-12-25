using System.Collections.Generic;
using System.Threading.Tasks;
using ArenaREST.Models;
using ArenaREST.Repositories;

namespace ArenaREST.Services
{
    public class MenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<MenuItem> GetMenuItemsForEvent(int eventId)
        {
            return _menuRepository.GetMenuItemsForEvent(eventId);
        }

        public async Task<MenuItem> AddMenuItem(MenuItem menuItem)
        {
            return await _menuRepository.AddMenuItem(menuItem);
        }

        public async Task<bool> DeleteMenuItem(int itemId)
        {
            return await _menuRepository.DeleteMenuItem(itemId);
        }
    }
}
