using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class AddStockCommand : IRequest<Stock>
    {
        public Stock Stock { get; set; }

        public AddStockCommand(Stock stock)
        {
            Stock = stock;
        }
    }
}
