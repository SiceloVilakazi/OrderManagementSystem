namespace OrderManagementSystem.Domain
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStateService _orderStateService;

        public OrderService(IOrderRepository orderRepository,IOrderStateService orderStateService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderStateService = orderStateService;
        }
        public async Task<Order> CancelOrder(int orderId)
        {
            var state = await _orderStateService.GetOrderState("Cancelled");
            var order = await _orderRepository.GetAsync(x => x.OrderId == orderId);
            var orderstate = await GetOrderState(orderId);

            if(orderstate != state.OrderStateId)
            {
                order.OrderStateId = state.OrderStateId;
                await _orderRepository.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
            }
            return order;
            
        }

        public async Task<Order> CompleteOrder(int orderId)
        {
            var state = await _orderStateService.GetOrderState("Completed");
            var order = await _orderRepository.GetAsync(x => x.OrderId == orderId);

            order.OrderStateId = state.OrderStateId;
            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
           var orders = await _orderRepository.ListAsync(x=>x.CreatedDateUtc.ToShortDateString()
                                                      ==date.ToShortDateString());
            return orders;
        }

        public async Task<Order> GetOrderByName(string Name)
        {
            var order = await _orderRepository.GetAsync(x => x.Name == Name);
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var Orders = await _orderRepository.ListAsync();
            return Orders;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            try
            {
               var state = await _orderStateService.GetOrderState("Reserved");
               var saved = await _orderRepository.AddAsync(new Order
               {
                   Quantity=order.Quantity,
                   ProductId=order.ProductId,
                   Name=order.Name,
                   OrderStateId=state.OrderStateId,
                   CreatedDateUtc=DateTime.Now,

               });
             return saved;
            }
            catch (Exception ex)
            { }
            return order;
        }

        internal async Task<int> GetOrderState(int OrderId)
        {
            var order = await _orderRepository.GetAsync(x=>x.OrderId == OrderId);
            return order.OrderStateId;
        }
    }
}
