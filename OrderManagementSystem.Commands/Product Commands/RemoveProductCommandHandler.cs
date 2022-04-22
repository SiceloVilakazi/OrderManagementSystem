
using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
    {
        private readonly IProductService _productService;

        public RemoveProductCommandHandler(IProductService productService)
        {
             _productService = productService;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _productService.DeleteProductAsync(request.Id);
            return  Unit.Value;
        }
    }
}
