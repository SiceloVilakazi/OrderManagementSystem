namespace OrderManagementSystem.Domain
{
    public interface IStockService
    {
        Task<Stock> GetAvailableStock(string productName);
        Task<Stock> AddStock(Stock stock);

        Task<Stock> UpdateStock(Stock stock);

        Task<Stock> GetStock(int ProductId);
    }
}
