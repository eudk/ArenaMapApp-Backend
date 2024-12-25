using ArenaREST.Models;
using ArenaREST.Repositories;
using System;
using System.IO;
using System.Threading.Tasks;
using QRCoder;

namespace ArenaREST.Services
{
    public class QRService
    {
        private readonly QRRepository _qrRepository;
        private readonly OrderRepository _orderRepository;

        public QRService(QRRepository qrRepository, OrderRepository orderRepository)
        {
            _qrRepository = qrRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> GenerateQRCodeForOrder(int orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var qrContent = $"Order ID: {orderId}, Email: {order.Email}";
            var qrBase64 = GenerateQRCodeAsBase64(qrContent);

            await _qrRepository.SaveQRCode(orderId, qrBase64);

            return qrBase64;
        }

        public async Task<string?> GetQRCodeByOrderId(int orderId)
        {
            return await _qrRepository.GetQRCode(orderId);
        }

        private string GenerateQRCodeAsBase64(string content)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);

            using (var stream = new MemoryStream())
            {
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
