using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManagementSystem.API.Controllers;
using OrderManagementSystem.Domain;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderManagementSystem.Tests.ControllerTests
{
    public class StockControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly ProductsDbEntitiesMock productsDbEntitiesMock;

        public StockControllerTest()
        {
            _mediator = new Mock<IMediator>();
            productsDbEntitiesMock = new ProductsDbEntitiesMock();
        }

        [Fact]
        public async Task GetAvailableStockTest()
        {
            var stock = productsDbEntitiesMock.GetTestStock().Where(s => s.ProductId==1).FirstOrDefault();

            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<Stock>>(), default)).Returns(Task.FromResult(stock));
            var controller = new StockController(_mediator.Object);

            //Act
            var result = await controller.GetAvailableStock("Azure fundamentals");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(stock, result);
        }
        [Fact]
        public async Task AddStock()
        {
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<Stock>>(), default));
            var controller = new StockController(_mediator.Object);

            var stock = new Stock
            {
               StockId = 4,
               ProductId = 1,
               AvailableStock = 120
            };

            //Act
            var results = await controller.AddStock(stock);

            //Assert
            Assert.NotNull(results);
            Assert.IsAssignableFrom<OkObjectResult>(results);
        }
    }
}
