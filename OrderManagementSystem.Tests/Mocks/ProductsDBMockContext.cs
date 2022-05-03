using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrderManagementSystem.Infrastructure;

namespace OrderManagementSystem.Tests
{
    public class ProductsDBMockContext : DbContextMockBase<OrderManagementDBContext>
    {
        private readonly ProductsDbEntitiesMock _productsDbEntities;
        public ProductsDBMockContext()
        {
            _productsDbEntities = new ProductsDbEntitiesMock();
        }
        public override OrderManagementDBContext GetDbContext()
        {
            var mockDb = InitializeDb();
            PopulateEntities(mockDb);
            return mockDb;
        }

        public override void PopulateEntities(OrderManagementDBContext productsDBContextMock)
        {
            productsDBContextMock.AddRange(_productsDbEntities.GetTestProducts());
            productsDBContextMock.AddRange(_productsDbEntities.GetTestOrders());
            productsDBContextMock.AddRange(_productsDbEntities.GetTestStock());
            productsDBContextMock.AddRange(_productsDbEntities.GetTestOrderStates());

            productsDBContextMock.SaveChanges();
        }

        private OrderManagementDBContext InitializeDb()
        {
            var mockDb = new DbContextOptionsBuilder<OrderManagementDBContext>()
             .UseInMemoryDatabase("ProductsMockDB")
             .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
             .EnableDetailedErrors()
             .EnableSensitiveDataLogging()
             .Options;

            var context = new OrderManagementDBContext(mockDb);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }

}
