using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetOrdersByDateQueryHandler : IRequestHandler<GetOrdersByDateQuery, List<Order>>
    {
        private readonly IOrderService _orderService;

        public GetOrdersByDateQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<List<Order>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersByDate(request.Date);
            return orders;
        }
    }
}
