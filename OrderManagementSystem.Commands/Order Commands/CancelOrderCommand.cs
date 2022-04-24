using MediatR;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Commands
{
    public class CancelOrderCommand : IRequest<string>
    {
        public int Id { get; set; }

        public CancelOrderCommand(int id)
        {
            Id= id;
        }
    }
}
