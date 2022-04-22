namespace OrderManagementSystem.Domain
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();

        Task<Order> GetOrderByName(string Name);

        Task<List<Order>> GetOrdersByDate(DateTime date);

        Task<Order> PlaceOrder(Order order);

        Task<Order> CancelOrder(int orderId);

        Task<Order> CompleteOrder(int orderId);
    }
}
