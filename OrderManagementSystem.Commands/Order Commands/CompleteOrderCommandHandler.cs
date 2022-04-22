using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, Order>
    {
        private IOrderService _orderService;

        public CompleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<Order> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var completed = await _orderService.CompleteOrder(request.Id);
            return completed;
        }
    }
}
