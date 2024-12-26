namespace ArenaREST.Models
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public decimal Price { get; set; }
        public string StallType { get; set; }  
    }
}
