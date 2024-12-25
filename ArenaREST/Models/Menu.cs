namespace ArenaREST.Models
{
    public class Menu
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; } // FK for Event
    }
}
