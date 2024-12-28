using ArenaREST.Models;
using ArenaREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrders()
        {
            var activeOrders = await _orderService.GetActiveOrders();
            return Ok(activeOrders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var createdOrder = await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetActiveOrders), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpGet("{orderId}/complete")]
        public async Task<IActionResult> MarkOrderAsCompleted(int orderId)
        {
            var success = await _orderService.MarkOrderAsCompleted(orderId);

            if (!success)
            {
                return NotFound(new { Message = "Order not found" });
            }

            return Ok(new { Message = "Order marked as completed" });
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound(new { Message = "Order not found" });
            }

            return Ok(order); 
        }

    }
}
