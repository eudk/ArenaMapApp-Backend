using ArenaREST.Models;

public class Order
{
    public int OrderId { get; set; }
    public string Email { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime OrderDate { get; set; }
    public int StallId { get; set; }
    public Stall Stall { get; set; }
    public int MenuItemID { get; set; } // Foreign Key
    public MenuItem MenuItem { get; set; }
    public string? QRCodeBase64 { get; set; } // Base64 QR Code
}
