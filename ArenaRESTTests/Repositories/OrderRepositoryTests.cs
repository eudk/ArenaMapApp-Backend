using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArenaREST.Context;
using ArenaREST.Repositories;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace ArenaREST.Repositories.Tests
{
    [TestClass()]
    public class OrderRepositoryTests
    {
        private static OrderRepository _repo;
        private static ArenaDbContext _dbContext;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            string appSettingsJson = Environment.GetEnvironmentVariable("APPSETTINGS_JSON");

            if (string.IsNullOrEmpty(appSettingsJson))
            {
                throw new Exception("APPSETTINGS_JSON environment variable is not set.");
            }

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettingsJson)))
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ArenaDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _dbContext = new ArenaDbContext(optionsBuilder.Options);
            _repo = new OrderRepository(_dbContext);
        }


        [TestMethod()]
        public async Task CreateOrderTest()
        {
            // Arrange
            var order = new Order
            {
                Email = "test@example.com",
                TotalAmount = 50m,
                IsCompleted = false
            };

            // Act
            var createdOrder = await _repo.CreateOrder(order);

            // Assert
            Assert.IsNotNull(createdOrder);
            Assert.AreEqual(order.Email, createdOrder.Email);

            // Cleanup
            _dbContext.Orders.Remove(createdOrder);
            await _dbContext.SaveChangesAsync();
        }

        [TestMethod()]
        public async Task GetActiveOrdersTest()
        {
            // Arrange
            var order = new Order
            {
                Email = "active@example.com",
                TotalAmount = 100m,
                IsCompleted = false
            };
            await _repo.CreateOrder(order);

            // Act
            var activeOrders = await _repo.GetActiveOrders();

            // Assert
            Assert.IsTrue(activeOrders.Any(o => o.Email == "active@example.com"));

            // Cleanup
            var createdOrder = _dbContext.Orders.FirstOrDefault(o => o.Email == "active@example.com");
            if (createdOrder != null)
            {
                _dbContext.Orders.Remove(createdOrder);
                await _dbContext.SaveChangesAsync();
            }
        }

        [TestMethod()]
        public async Task MarkOrderAsCompletedTest()
        {
            // Arrange
            var order = new Order
            {
                Email = "complete@example.com",
                TotalAmount = 150m,
                IsCompleted = false
            };
            var createdOrder = await _repo.CreateOrder(order);

            // Act
            var result = await _repo.MarkOrderAsCompleted(createdOrder.OrderId);

            // Assert
            Assert.IsTrue(result);

            // Cleanup
            var updatedOrder = await _repo.GetOrderById(createdOrder.OrderId);
            if (updatedOrder != null)
            {
                _dbContext.Orders.Remove(updatedOrder);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
