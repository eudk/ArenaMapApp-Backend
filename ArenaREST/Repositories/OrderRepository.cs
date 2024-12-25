using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaREST.Repositories
{
    public class OrderRepository
    {
        private readonly ArenaDbContext _context;

        public OrderRepository(ArenaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetActiveOrders()
        {
            return await _context.Orders
                .Where(order => !order.IsCompleted)
                .Include(order => order.MenuItem)
                .ToListAsync();
        }

        public async Task<bool> MarkOrderAsCompleted(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.IsCompleted = true;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(order => order.MenuItem) 
                .FirstOrDefaultAsync(order => order.OrderId == orderId);
        }

    }
}
