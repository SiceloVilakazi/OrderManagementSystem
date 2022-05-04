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

            _unitOfWorkMock.Setup(x => x.CommitAsync());

            _orderserviceMock.Setup(x => x.GetOrders()).Returns((System.Threading.Tasks.Task<System.Collections.Generic.List<Order>>)
                                    _productsDbEntitiesMock.GetTestOrders());
        }

        //[Fact]
        //public void TestCreateDBProducts()
        //{
        //    var dbContext = _productsDBMockContext.GetDbContext();
        //    var repo = new Repository<Product>(dbContext);

        //    var preProductCreationCount = dbContext.Products.Count();

        //    var product = new Product
        //    {
        //        ProductId = 10,
        //        Description = "Microservices",
        //        Name = "Microservices",
        //        Price = 45
        //    };

        //    repo.Add(product);
        //    repo.Save();

        //    var postProductCreationCount = dbContext.Products.Count();

        //    Assert.NotEqual(preProductCreationCount, postProductCreationCount);
        //    Assert.Equal(preProductCreationCount + 1, postProductCreationCount);
        //}


    }
}