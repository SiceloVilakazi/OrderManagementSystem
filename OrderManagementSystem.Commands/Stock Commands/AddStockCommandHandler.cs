using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, Stock>
    {
        private readonly IStockService _stockService;

        public AddStockCommandHandler(IStockService stockService)
        {
            _stockService = stockService;
        }
        public async Task<Stock> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var addedStock = await _stockService.AddStock(request.Stock);
            return addedStock;
        }
    }
}
