namespace ArenaREST.DTOs
{
    public class ActiveOrderDto
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
