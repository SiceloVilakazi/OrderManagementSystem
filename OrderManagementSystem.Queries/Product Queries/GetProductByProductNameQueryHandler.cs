
using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetProductByProductNameQueryHandler : IRequestHandler<GetProductByProductNameQuery, Product>
    {
        private readonly IProductService _productService;

        public GetProductByProductNameQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductByProductNameQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByNameAsync(request.ProductName);
            return product;
        }
    }
}
