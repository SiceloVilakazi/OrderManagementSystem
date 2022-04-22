namespace OrderManagementSystem.Domain
{
    public interface IStockService
    {
        Task<Stock> GetAvailableStock(string productName);
        Task<Stock> AddStock(Stock stock);
    }
}
