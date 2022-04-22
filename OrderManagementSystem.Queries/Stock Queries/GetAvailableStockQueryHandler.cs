using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetAvailableStockQueryHandler : IRequestHandler<GetAvailableStockQuery, Stock>
    {
        private readonly IStockService _stockService;

        public GetAvailableStockQueryHandler(IStockService stockService)
        {
            _stockService = stockService;
        }
        public async Task<Stock> Handle(GetAvailableStockQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockService.GetAvailableStock(request.ProductName);
            return stock;
        }
    }
}
