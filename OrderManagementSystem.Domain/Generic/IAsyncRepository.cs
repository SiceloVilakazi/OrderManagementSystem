using System.Linq.Expressions;

namespace OrderManagementSystem.Domain;

    public interface IAsyncRepository<Tentity> where Tentity : class
    {
        Task<List<Tentity>> ListAsync();
        Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> expression);

        Task<List<Tentity>> ListAsync(Expression<Func<Tentity, bool>> expression);
        Task<Tentity> AddAsync(Tentity entity);
        Task<Tentity> UpdateAsync(Tentity entity);
        Task<bool> DeleteAsync(Tentity entity);

        Task<int> CountAsync();
    }
