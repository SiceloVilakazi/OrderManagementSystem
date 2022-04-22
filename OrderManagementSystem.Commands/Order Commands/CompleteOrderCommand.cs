using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CompleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }

        public CompleteOrderCommand(int id)
        {
            Id= id;
        }
    }
}
