namespace OrderManagementSystem.Domain
{
    public class StockService : BaseService, IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        public StockService(IStockRepository stockRepository,IProductRepository productRepository
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }

        public async Task<Stock> GetAvailableStock(string productName)
        {
            var product = await _productRepository.GetAsync(x=>x.Name == productName);
            var stock = await _stockRepository.GetAsync(x=>x.ProductId == product.ProductId);
            return stock;
        }
        public async Task<Stock> AddStock(Stock stock)
        {
            var addedStock = await _stockRepository.AddAsync(stock);
            await UnitOfWork.CommitAsync();
            return addedStock;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            var updated=await _stockRepository.UpdateAsync(stock);
            await UnitOfWork.CommitAsync();
            return updated;
        }

        public async Task<Stock> GetStock(int ProductId)
        {
            var stock = await _stockRepository.GetAsync(x=>x.ProductId==ProductId);
            return stock;
        }
    }
}
