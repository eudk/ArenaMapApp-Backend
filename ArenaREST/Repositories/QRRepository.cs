using ArenaREST.Context;
using System.Threading.Tasks;

namespace ArenaREST.Repositories
{
    public class QRRepository
    {
        private readonly ArenaDbContext _context;

        public QRRepository(ArenaDbContext context)
        {
            _context = context;
        }

        public async Task SaveQRCode(int orderId, string qrCodeBase64)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.QRCodeBase64 = qrCodeBase64;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string?> GetQRCode(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            return order?.QRCodeBase64;
        }
    }
}
