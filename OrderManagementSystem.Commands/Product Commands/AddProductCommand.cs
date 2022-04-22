using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }

        public AddProductCommand(Product product)
        {
            Product = product;
        }
    }
}
