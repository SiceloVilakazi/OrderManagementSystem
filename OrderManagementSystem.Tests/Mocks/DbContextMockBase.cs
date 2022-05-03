using Microsoft.EntityFrameworkCore;

namespace OrderManagementSystem.Tests
{
    public abstract class DbContextMockBase<TDbContext> where TDbContext : DbContext
    {
        public abstract TDbContext GetDbContext();
        public abstract void PopulateEntities(TDbContext dbContext);
    }
}
