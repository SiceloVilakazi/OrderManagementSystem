namespace OrderManagementSystem.Domain
{
    public interface IOrderStateService
    {
        Task<OrderState> GetOrderState(int OrderStateId);

        Task<OrderState> AddOrderState(OrderState orderState);

        Task<OrderState> GetOrderState(string state);

        public Task<IEnumerable<OrderState>> GetCachedOrderStates();

        public Task<OrderState> GetCachedOrderStatesByKey(int orderStateId);
    }
}
