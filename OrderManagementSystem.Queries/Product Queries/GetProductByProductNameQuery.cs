using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetProductByProductNameQuery : IRequest<Product>
    {
        public string ProductName { get; set; }

        public GetProductByProductNameQuery(string productname)
        {
           ProductName = productname;
        }
    }
}
