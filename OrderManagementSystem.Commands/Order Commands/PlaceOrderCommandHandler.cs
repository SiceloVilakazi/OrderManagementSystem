using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, string>
    {
        private readonly IOrderService _orderService;

        public PlaceOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<string> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var placed = await _orderService.PlaceOrder(request.Order);
            return placed;
        }
    }
}
