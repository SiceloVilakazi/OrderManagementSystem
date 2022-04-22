using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Infrastructure
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(OrderManagementDBContext dBContext) : base(dBContext)
        {}
    }
}
