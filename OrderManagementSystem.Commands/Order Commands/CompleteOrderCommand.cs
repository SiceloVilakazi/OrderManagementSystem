using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CompleteOrderCommand : IRequest<string>
    {
        public int Id { get; set; }

        public CompleteOrderCommand(int id)
        {
            Id= id;
        }
    }
}
