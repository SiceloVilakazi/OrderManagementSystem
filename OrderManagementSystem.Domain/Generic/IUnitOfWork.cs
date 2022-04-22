namespace OrderManagementSystem.Domain;
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }

