using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Infrastructure
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(OrderManagementDBContext dBContext):base(dBContext)
        { }
    }
}
