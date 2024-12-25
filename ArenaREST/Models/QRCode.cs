namespace ArenaREST.Models
{
    public class QRCode
    {
        public int QRCodeId { get; set; } 
        public int OrderId { get; set; } 
        public string QRCodeBase64 { get; set; } 

        // Navigation property
        public Order Order { get; set; }
    }
}
