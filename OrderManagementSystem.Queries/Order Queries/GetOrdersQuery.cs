using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {
    }
}
