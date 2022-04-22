namespace OrderManagementSystem.Domain
{
    public interface IOrderStateService
    {
        Task<OrderState> GetOrderState(int OrderStateId);

        Task<OrderState> AddOrderState(OrderState orderState);

        Task<OrderState> GetOrderState(string state);
    }
}
