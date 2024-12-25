namespace ArenaREST.Models
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } // Base64
        public double Price { get; set; }
        public int EventID { get; set; } // Foreign key to Events
    }
}
