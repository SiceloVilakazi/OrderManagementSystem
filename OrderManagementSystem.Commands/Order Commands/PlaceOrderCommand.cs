using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class PlaceOrderCommand : IRequest<string>
    {
        public Order Order { get; set; }
        public PlaceOrderCommand(Order order)
        {
            Order = order;
        }
    }
}
