using ArenaREST.Models;
using ArenaREST.Repositories;

namespace ArenaREST.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetActiveOrders()
        {
            return await _orderRepository.GetActiveOrders();
        }

        public async Task<bool> MarkOrderAsCompleted(int orderId)
        {
            return await _orderRepository.MarkOrderAsCompleted(orderId);
        }
    }
}
