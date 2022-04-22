using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class AddOrderStateCommandHandler : IRequestHandler<AddOrderStateCommand, OrderState>
    {
        private readonly IOrderStateService _orderStateService;

        public AddOrderStateCommandHandler(IOrderStateService orderStateService)
        {
            _orderStateService = orderStateService;
        }
        public async Task<OrderState> Handle(AddOrderStateCommand request, CancellationToken cancellationToken)
        {
            var addedOrderState = await _orderStateService.AddOrderState(request.OrderState);
            return addedOrderState;
        }
    }
}
