using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetOrderByNameQuery : IRequest<Order>
    {
        public string OrderName { get; set; }

        public GetOrderByNameQuery(string orderName)
        {
                OrderName = orderName;
        }
    }
}
