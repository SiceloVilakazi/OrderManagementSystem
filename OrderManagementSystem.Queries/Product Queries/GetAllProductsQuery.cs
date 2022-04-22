using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetAllProductsQuery :IRequest<List<Product>>
    {
    }
}
