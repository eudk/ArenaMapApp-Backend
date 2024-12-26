using ArenaREST.Models;
using ArenaREST.Repositories;

public class MenuService
{
    private readonly MenuRepository _menuRepository;

    public MenuService(MenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public IEnumerable<MenuItem> GetMenuItemsByType(string stallType)
    {
        return _menuRepository.GetMenuItemsByType(stallType);
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