namespace ArenaREST.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }
        public string QrCodeUrl => $"https://your-domain.com/api/order/{OrderId}/complete"; 
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 
    }
}
