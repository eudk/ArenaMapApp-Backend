using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

public class OrderRepository
{
    private readonly ArenaDbContext _context;

    public OrderRepository(ArenaDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetActiveOrders()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .Where(o => !o.IsCompleted)
            .ToListAsync();
    }

    public async Task<bool> MarkOrderAsCompleted(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null) return false;

        order.IsCompleted = true;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Order?> GetOrderById(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }


}
