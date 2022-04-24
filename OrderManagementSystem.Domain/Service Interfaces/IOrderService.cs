namespace OrderManagementSystem.Domain
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();

        Task<Order> GetOrderByName(string Name);

        Task<List<Order>> GetOrdersByDate(DateTime date);

        Task<string> PlaceOrder(Order order);

        Task<string> CancelOrder(int orderId);

        Task<string> CompleteOrder(int orderId);
    }
}
