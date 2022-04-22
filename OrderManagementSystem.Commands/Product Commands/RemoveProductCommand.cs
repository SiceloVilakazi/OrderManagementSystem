
using MediatR;

namespace OrderManagementSystem.Commands
{
    public class RemoveProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
