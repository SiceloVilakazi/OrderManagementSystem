using Moq;
using OrderManagementSystem.Domain;
using Xunit;

namespace OrderManagementSystem.Tests
{
    public class OrderServiceTest
    {
        private readonly Mock<OrderService> _orderserviceMock;
        private readonly Mock<IStockService> _stockServiceMock;
        private readonly Mock<IOrderStateService> _orderStateserviceMock;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly ProductsDbEntitiesMock _productsDbEntitiesMock;

        public OrderServiceTest()
        {
            _orderserviceMock = new Mock<OrderService>();
            _stockServiceMock = new Mock<IStockService>();
            _orderStateserviceMock = new Mock<IOrderStateService>();
            _productServiceMock = new Mock<IProductService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _productsDbEntitiesMock = new ProductsDbEntitiesMock();

            _orderserviceMock.Setup(x => x.GetOrders()).Returns((System.Threading.Tasks.Task<System.Collections.Generic.List<Order>>)
                                    _productsDbEntitiesMock.GetTestOrders());
        }
        [Fact]
        public void TestGetOrders()
        {
            var service = new OrderService(_orderserviceMock.Object, _productServiceMock.Object, _orderStateserviceMock.Object, _stockServiceMock.Object);
        }
    }
}