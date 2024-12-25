using ArenaREST.Models;

public class Order
{
    public int OrderId { get; set; } // Primary Key
    public string Email { get; set; }
    public int MenuItemId { get; set; }
    public bool IsCompleted { get; set; }

    // Navigation property for MenuItem
    public MenuItem MenuItem { get; set; }

    // Navigation property for QRCode
    public QRCode QRCode { get; set; }

    // Convenience property for QRCodeBase64
    public string? QRCodeBase64
    {
        get => QRCode?.QRCodeBase64;
        set
        {
            if (QRCode != null)
            {
                QRCode.QRCodeBase64 = value;
            }
        }
    }
}
