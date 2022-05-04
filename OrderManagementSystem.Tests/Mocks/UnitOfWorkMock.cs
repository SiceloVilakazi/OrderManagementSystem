using OrderManagementSystem.Domain;
using System.Threading.Tasks;

namespace OrderManagementSystem.Tests
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        private readonly ProductsDBMockContext _productsDBMockContext;

        public UnitOfWorkMock(ProductsDBMockContext productsDBMockContext)
        {
            _productsDBMockContext = new ProductsDBMockContext();
        }

        public async Task CommitAsync()
        {
          var dbContext = _productsDBMockContext.GetDbContext();
           await dbContext.SaveChangesAsync();
        }
    }
}
