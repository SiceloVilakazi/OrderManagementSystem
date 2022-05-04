

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManagementSystem.API.Controllers;
using OrderManagementSystem.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderManagementSystem.Tests.ControllerTests
{
    public class ProductControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly ProductsDbEntitiesMock productsDbEntitiesMock;

        public ProductControllerTest()
        {
            _mediator = new Mock<IMediator>();
            productsDbEntitiesMock = new ProductsDbEntitiesMock();

        }
        [Fact]
        public async Task GetAllProductsTest()
        {
            var products = productsDbEntitiesMock.GetTestProducts();
            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<List<Product>>>(), default)).Returns(Task.FromResult(products.ToList()));
            var controller = new ProductController(_mediator.Object);

            //Act
            var result = await controller.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }
        [Fact]
        public async Task GetProductByProductNameTest()
        {
            var product = productsDbEntitiesMock.GetTestProducts().Where(x => x.Name == "Azure fundamentals").FirstOrDefault();

            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<Product>>(), default)).Returns(Task.FromResult(product));
            var controller = new ProductController(_mediator.Object);

            //Act
            var result = await controller.GetByProductName("Azure fundamentals");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result);
        }
        [Fact]
        public async Task CreateProductTest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<Product>>(), default));
            var controller = new ProductController(_mediator.Object);

            var product = new Product
            {
                Name = "C# Basics",
                Description = "C# Basics",
                Price = 500
            };

            //Act
            var results = await controller.AddProduct(product);

            //Assert
            Assert.NotNull(results);
            Assert.IsAssignableFrom<OkObjectResult>(results);
        }

        [Fact]
        public async void RemoveProductTest()
        {
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<Product>>(), default));
            var controller = new ProductController(_mediator.Object);

            //Act
            var result = await controller.RemoveProduct(1);

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
