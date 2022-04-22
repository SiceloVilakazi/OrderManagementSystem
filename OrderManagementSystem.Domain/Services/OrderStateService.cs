namespace OrderManagementSystem.Domain
{
    public class OrderStateService : BaseService, IOrderStateService
    {
        private readonly IOrderStateRepository _orderStateRepository;
        public OrderStateService(IOrderStateRepository orderStateRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderStateRepository = orderStateRepository;
        }

        public async Task<OrderState> AddOrderState(OrderState orderState)
        {
            var addedOrderState = new OrderState();
            try
            {
                addedOrderState = await _orderStateRepository.AddAsync(orderState);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            { }
            return addedOrderState;
        }

        public async Task<OrderState> GetOrderState(int OrderStateId)
        {
            var orderState = await _orderStateRepository.GetAsync(x => x.OrderStateId == OrderStateId);
            return orderState;
        }
        
        public async Task<OrderState> GetOrderState(string state)
        {
            var orderState = await _orderStateRepository.GetAsync(x=>x.State == state);
            return orderState;
        }
    }
}
