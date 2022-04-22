using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Queries
{
    public class GetOrdersByDateQuery : IRequest<List<Order>>
    {
        public DateTime Date { get; set; }

        public GetOrdersByDateQuery(DateTime date)
        {
            Date = date;
        }
    }
}
