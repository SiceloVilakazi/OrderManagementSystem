using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Infrastructure
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderManagementDBContext dBContext) : base(dBContext)
        {}
    }
}
