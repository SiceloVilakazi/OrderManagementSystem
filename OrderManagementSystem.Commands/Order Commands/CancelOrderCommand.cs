using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CancelOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }

        public CancelOrderCommand(int id)
        {
            Id= id;
        }
    }
}
