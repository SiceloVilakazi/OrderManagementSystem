using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetOrderByNameQueryHandler : IRequestHandler<GetOrderByNameQuery, Order>
    {
        private readonly IOrderService _orderService;

        public GetOrderByNameQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<Order> Handle(GetOrderByNameQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByName(request.OrderName);
            return order;
        }
    }
}
