using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDBContext _dbContext;

        public UnitOfWork(OrderManagementDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
