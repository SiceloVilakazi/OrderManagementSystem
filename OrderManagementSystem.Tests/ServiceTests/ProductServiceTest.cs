using Moq;
using OrderManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderManagementSystem.Tests.ServiceTests
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.CommitAsync());
        }

        [Fact]
        public async Task AddProduct()
        {
            var service = new ProductService(_productRepository.Object, _unitOfWork.Object);
            var product = new Product
            {
                Name = "C# Basics",
                Description = "C# Basics",
                Price = 500
            };

            //Act
            var addedProduct = await service.AddProductAsync(product);
            
            //Arrange
            _productRepository.Verify(x=>x.AddAsync(product), Times.Once());
            _unitOfWork.Verify(x=>x.CommitAsync(), Times.Once());

          //  var productadded = await service.GetProductByNameAsync(product.Name);

          //  Assert - to be fixed
           // Assert.NotNull(productadded);
           // Assert.Equal(product.Name, addedProduct.Name);
        }
    }
}
