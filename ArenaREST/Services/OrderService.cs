using ArenaREST.Models;
using ArenaREST.Repositories;
using QRCoder;
using System.Drawing;
using System.IO;
using ArenaREST.DTOs;

public class OrderService
{
    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        return await _orderRepository.CreateOrder(order);
    }

    public async Task<IEnumerable<ActiveOrderDto>> GetActiveOrders()
    {
        return await _orderRepository.GetActiveOrders();
    }

    public async Task<bool> MarkOrderAsCompleted(int orderId)
    {
        return await _orderRepository.MarkOrderAsCompleted(orderId);
    }

    public async Task<Order?> GetOrderById(int orderId)
    {
        return await _orderRepository.GetOrderById(orderId);
    }



}
