using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetAvailableStockQuery: IRequest<Stock>
    {
        public string ProductName { get; set; }
        public GetAvailableStockQuery(string productName)
        {
            ProductName= productName;
        }
    }
}
