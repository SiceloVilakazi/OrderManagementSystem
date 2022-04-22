using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Order>
    {
        private readonly IOrderService _orderService;

        public CancelOrderCommandHandler(IOrderService orderService)
        {
            _orderService= orderService;
        }
        public async Task<Order> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var cancelled = await _orderService.CancelOrder(request.Id);
            return cancelled;
        }
    }
}
