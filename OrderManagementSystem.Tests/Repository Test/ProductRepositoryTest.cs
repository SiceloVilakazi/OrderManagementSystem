

using Moq;
using OrderManagementSystem.Domain;
using OrderManagementSystem.Infrastructure;
using System;
using System.Linq;
using Xunit;

namespace OrderManagementSystem.Tests
{
    public class ProductRepositoryTest 
    {
        private readonly ProductsDBMockContext _productsDBMockContext;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public ProductRepositoryTest()
        {
            _productsDBMockContext = new ProductsDBMockContext();
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.CommitAsync());
        }
        [Fact]
        public void TestCreateDBOrders()
        {
            var dbContext = _productsDBMockContext.GetDbContext();
            var repo = new BaseRepository<Order>(dbContext);

            var preOrderCreationCount = dbContext.Orders.Count();

            var newOrder = new Order
            {
                OrderId = 11,
                ProductId = 10,
                Name = "My Order",
                Quantity = 45,
                CreatedDateUtc = DateTime.UtcNow,
                OrderStateId = 1
            };

            repo.AddAsync(newOrder);
            //_unitOfWork.Co;

             var postOrderCreationCount = dbContext.Orders.Count();

            Assert.NotEqual(preOrderCreationCount, postOrderCreationCount);
            Assert.Equal(preOrderCreationCount + 1, postOrderCreationCount);

            var order = repo.GetAsync(x=>x.OrderId==newOrder.OrderId).Result;

            Assert.NotNull(order);
            Assert.Equal(newOrder.OrderId, order.OrderId);

            var orders = repo.ListAsync(x => x.OrderId == newOrder.OrderId).Result;

            Assert.NotNull(orders);
        }

    }
}
