using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Infrastructure
{
    public class OrderStateRepository : BaseRepository<OrderState>, IOrderStateRepository
    {
        public OrderStateRepository(OrderManagementDBContext dBContext) : base(dBContext)
        { }
    }
}
