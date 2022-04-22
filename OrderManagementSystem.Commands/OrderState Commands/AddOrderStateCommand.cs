using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class AddOrderStateCommand : IRequest<OrderState>
    {
        public OrderState OrderState { get; set; }

        public AddOrderStateCommand(OrderState orderState)
        {
            OrderState = orderState;
        }
    }
}
