using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;
using ArenaREST.DTOs;

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

    public async Task<IEnumerable<ActiveOrderDto>> GetActiveOrders()
    {
        return await _context.Orders
            .Where(o => !o.IsCompleted)
            .Select(o => new ActiveOrderDto
            {
                OrderId = o.OrderId,
                Email = o.Email,
                TotalAmount = o.TotalAmount,
                CreatedAt = o.CreatedAt,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    MenuItemId = oi.MenuItemId,
                    MenuItemName = oi.MenuItem != null ? oi.MenuItem.Name : "Unknown",
                    Quantity = oi.Quantity
                }).ToList()
            })
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
